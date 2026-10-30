
using Microsoft.AspNetCore.Mvc;
using shiftIQ.API.DTOs;
using ShiftIQ.API.Models;
using System.Collections.Concurrent;

namespace shiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceCorrectionController : ControllerBase
    {
        private static readonly ConcurrentDictionary<int, AttendanceCorrection>
            MockCorrections = new();

        private static int _nextId = 0;
        private const int MockApproverMembershipId = 100;

        [HttpPost]
        public IActionResult CreateCorrection(
            [FromBody] CreateAttendanceCorrection request)
        {
            if (request.AttendanceRecordId <= 0)
                return BadRequest("Invalid attendance record ID.");

            if (string.IsNullOrWhiteSpace(request.Reason))
                return BadRequest("Reason is required.");

            if (request.RequestedCheckInAt == null &&
                request.RequestedCheckOutAt == null)
                return BadRequest("Provide a requested check-in or check-out time.");

            if (request.RequestedCheckInAt.HasValue &&
                request.RequestedCheckOutAt.HasValue &&
                request.RequestedCheckOutAt <= request.RequestedCheckInAt)
                return BadRequest("Check-out must be after check-in.");

            var correction = new AttendanceCorrection
            {
                Id = Interlocked.Increment(ref _nextId),
                AttendanceRecordId = request.AttendanceRecordId,
                Reason = request.Reason,
                RequestedCheckInAt = request.RequestedCheckInAt,
                RequestedCheckOutAt = request.RequestedCheckOutAt,
                RequestedAt = DateTime.UtcNow,
                Status = "Pending"
            };

            MockCorrections.TryAdd(correction.Id, correction);

            return Ok(correction);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCorrection(int id)
        {
            if (!MockCorrections.TryGetValue(id, out var correction))
                return NotFound();

            return Ok(correction);
        }

        [HttpPut("{id:int}/review")]
        public IActionResult ReviewCorrection(
            int id,
            [FromBody] ReviewAttendanceCorrection request)
        {
            if (!MockCorrections.TryGetValue(id, out var correction))
                return NotFound();

            if (request.Decision != "Approved" &&
                request.Decision != "Rejected")
                return BadRequest("Decision must be Approved or Rejected.");

            if (request.ReviewedByMembershipId != MockApproverMembershipId)
                return Forbid();

            lock (correction)
            {
                if (correction.Status != "Pending")
                    return Conflict("This correction has already been reviewed.");

                correction.Status = request.Decision;
                correction.ReviewedAt = DateTime.UtcNow;
                correction.ReviewedByMembershipId =
                    request.ReviewedByMembershipId;
                correction.ReviewNote = request.ReviewNote;
            }

            return Ok(correction);
        }
    }
}
