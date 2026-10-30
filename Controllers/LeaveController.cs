
using Microsoft.AspNetCore.Mvc;
using shiftIQ.API.DTOs;
using ShiftIQ.API.Models;
using System.Collections.Concurrent;

namespace shiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        // Mock leave requests
        private static readonly ConcurrentDictionary<int, LeaveRequest>
            MockLeaveRequests = new();

        // Mock leave approvals
        private static readonly ConcurrentDictionary<int, LeaveApproval>
            MockLeaveApprovals = new();

        private static int _nextId = 0;

        // Temporary mock approver
        // This is only for testing until authentication is connected.
        private const int MockApproverMembershipId = 100;

        // POST: api/Leave
        [HttpPost]
        public IActionResult CreateLeaveRequest(
            [FromBody] CreateLeaveRequest request)
        {
            var today = DateTime.UtcNow.Date;

            // Validate start date
            if (request.StartDate.Date < today)
            {
                return BadRequest(new
                {
                    message = "Leave start date cannot be in the past."
                });
            }

            // Validate end date
            if (request.EndDate.Date < request.StartDate.Date)
            {
                return BadRequest(new
                {
                    message = "End date must be after or equal to start date."
                });
            }

            var leaveRequest = new LeaveRequest
            {
                Id = Interlocked.Increment(ref _nextId),
                EmployeeId = request.EmployeeId,
                LeaveTypeId = request.LeaveTypeId,
                SubmittedAt = DateTime.UtcNow,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = "Pending",
                Reason = request.Reason
            };

            MockLeaveRequests.TryAdd(
                leaveRequest.Id, leaveRequest);

            return Ok(new
            {
                message = "Leave request submitted successfully.",
                leaveRequest
            });
        }

        // GET: api/Leave/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetLeaveRequest(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message = "Invalid leave request ID."
                });
            }

            if (!MockLeaveRequests.TryGetValue(
                id, out var leaveRequest))
            {
                return NotFound(new
                {
                    message = "Leave request not found."
                });
            }

            return Ok(leaveRequest);
        }

        // PUT: api/Leave/{id}/review
        [HttpPut("{id:int}/review")]
        public IActionResult ReviewLeaveRequest(
            int id,
            [FromBody] ReviewLeaveRequest request)
        {
            // 1. Validate request ID
            if (id <= 0)
            {
                return BadRequest(new
                {
                    message = "Invalid leave request ID."
                });
            }

            // 2. Find leave request
            if (!MockLeaveRequests.TryGetValue(
                id, out var leaveRequest))
            {
                return NotFound(new
                {
                    message = "Leave request not found."
                });
            }

            // 3. Validate decision
            if (request.Decision != "Approved" &&
                request.Decision != "Rejected")
            {
                return BadRequest(new
                {
                    message = "Decision must be Approved or Rejected."
                });
            }

            // 4. Validate mock approver
            if (request.ApproverMembershipId !=
                MockApproverMembershipId)
            {
                return Forbid();
            }

            // 5. Prevent reviewing an already reviewed request
            if (leaveRequest.Status != "Pending")
            {
                return Conflict(new
                {
                    message = "This leave request has already been reviewed."
                });
            }

            // 6. Create approval record
            var approval = new LeaveApproval
            {
                Id = id,
                LeaveRequestId = id,
                ApproverMembershipId =
                    request.ApproverMembershipId,
                DecidedAt = DateTime.UtcNow,
                Decision = request.Decision,
                Comment = request.Comment
            };

            // 7. Save approval
            if (!MockLeaveApprovals.TryAdd(id, approval))
            {
                return Conflict(new
                {
                    message = "This leave request has already been reviewed."
                });
            }

            // 8. Update leave request status
            lock (leaveRequest)
            {
                if (leaveRequest.Status != "Pending")
                {
                    MockLeaveApprovals.TryRemove(id, out _);

                    return Conflict(new
                    {
                        message = "This leave request has already been reviewed."
                    });
                }

                leaveRequest.Status = request.Decision;
            }

            return Ok(new
            {
                message = "Leave request reviewed successfully.",
                leaveRequest,
                approval
            });
        }
    }
}
