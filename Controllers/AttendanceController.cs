
using Microsoft.AspNetCore.Mvc;
using shiftIQ.API.DTOs;
using ShiftIQ.API.Models;
using System.Collections.Concurrent;

namespace shiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        // Mock attendance records
        private static readonly ConcurrentDictionary<int, AttendanceRecord>
            MockAttendance = new();

        private static int _nextAttendanceId = 0;

        // Mock employee
        private const int MockEmployeeId = 1;

        // Mock shifts
        private static readonly Dictionary<int, Shift> MockShifts = new()
        {
            [1] = new Shift
            {
                ShiftId = 1,
                CompanyId = 1,
                Name = "Morning Shift",
                StartTime = TimeSpan.Zero,
                EndTime = new TimeSpan(23, 59, 0),
                GracePeriodMinutes = 15,
                IsActive = true
            }
        };

        // Mock shift assignments
        private static readonly Dictionary<int, ShiftAssignment>
            MockShiftAssignments = new()
            {
                [1] = new ShiftAssignment
                {
                    AssignmentId = 1,
                    EmployeeId = 1,
                    ShiftId = 1,
                    EffectiveFrom = DateTime.UtcNow.Date,
                    EffectiveTo = null
                },

                [2] = new ShiftAssignment
                {
                    AssignmentId = 2,
                    EmployeeId = 1,
                    ShiftId = 1,
                    EffectiveFrom = DateTime.UtcNow.Date,
                    EffectiveTo = null
                }
            };

        // Temporary mock branch location
        private const double BranchLatitude = 27.1809;
        private const double BranchLongitude = 31.1837;
        private const double GeofenceRadiusMeters = 200;

        // Calculate distance between GPS coordinates
        private static double CalculateDistance(
            double lat1, double lon1,
            double lat2, double lon2)
        {
            const double EarthRadiusMeters = 6371000;

            double lat1Rad = lat1 * Math.PI / 180;
            double lat2Rad = lat2 * Math.PI / 180;

            double deltaLat = (lat2 - lat1) * Math.PI / 180;
            double deltaLon = (lon2 - lon1) * Math.PI / 180;

            double a =
                Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(
                Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusMeters * c;
        }

        // Validate shift assignment and employee
        private static bool TryGetValidAssignment(
            int employeeId,
            int assignmentId,
            DateTime currentTime,
            out ShiftAssignment? assignment,
            out Shift? shift)
        {
            assignment = null;
            shift = null;

            if (employeeId != MockEmployeeId)
                return false;

            if (!MockShiftAssignments.TryGetValue(
                assignmentId, out var foundAssignment))
                return false;

            if (foundAssignment.EmployeeId != employeeId)
                return false;

            if (currentTime.Date < foundAssignment.EffectiveFrom.Date)
                return false;

            if (foundAssignment.EffectiveTo.HasValue &&
                currentTime.Date > foundAssignment.EffectiveTo.Value.Date)
                return false;

            if (!MockShifts.TryGetValue(
                foundAssignment.ShiftId, out var foundShift))
                return false;

            if (!foundShift.IsActive)
                return false;

            assignment = foundAssignment;
            shift = foundShift;

            return true;
        }

        // Check whether current time is inside the shift
        private static bool IsWithinShift(
            TimeSpan currentTime,
            Shift shift)
        {
            if (shift.StartTime <= shift.EndTime)
            {
                return currentTime >= shift.StartTime &&
                       currentTime <= shift.EndTime;
            }

            // Supports overnight shifts
            return currentTime >= shift.StartTime ||
                   currentTime <= shift.EndTime;
        }

        // POST: api/Attendance/check-in
        [HttpPost("check-in")]
        public IActionResult CheckIn(
            [FromBody] CheckInRequest request)
        {
            var now = DateTime.UtcNow;

            // 1. Validate employee and shift assignment
            if (!TryGetValidAssignment(
                request.EmployeeId,
                request.ShiftAssignmentId,
                now,
                out var assignment,
                out var shift))
            {
                return NotFound(new
                {
                    message = "Employee or active shift assignment not found."
                });
            }

            // 2. Validate shift time
            if (!IsWithinShift(now.TimeOfDay, shift!))
            {
                return BadRequest(new
                {
                    message = "Check-in is outside the scheduled shift time."
                });
            }

            // 3. Validate QR token
            if (request.QrToken != "TEST-QR-001")
            {
                return Unauthorized(new
                {
                    message = "Invalid QR token."
                });
            }

            // 4. Validate trusted device
            if (request.DeviceId != "TEST-DEVICE-001")
            {
                return Unauthorized(new
                {
                    message = "Device is not trusted for this employee."
                });
            }

            // 5. Validate GPS accuracy
            if (request.AccuracyMeters > 100)
            {
                return BadRequest(new
                {
                    message = "GPS accuracy is too low. Please retry."
                });
            }

            // 6. Calculate distance from branch
            double distance = CalculateDistance(
                request.Latitude,
                request.Longitude,
                BranchLatitude,
                BranchLongitude);

            // 7. Validate geofence
            if (distance > GeofenceRadiusMeters)
            {
                return BadRequest(new
                {
                    message = "You are outside the allowed branch location.",
                    distanceMeters = Math.Round(distance, 2),
                    allowedRadiusMeters = GeofenceRadiusMeters
                });
            }

            // 8. Prevent duplicate check-in
            if (MockAttendance.ContainsKey(
                request.ShiftAssignmentId))
            {
                return Conflict(new
                {
                    message = "Attendance already recorded for this shift."
                });
            }

            // 9. Create attendance record using server time
            var attendance = new AttendanceRecord
            {
                AttendanceId = Interlocked.Increment(
                    ref _nextAttendanceId),

                ShiftAssignmentId = assignment!.AssignmentId,
                CheckInAt = now,
                CheckOutAt = null,
                CheckInLatitude = request.Latitude,
                CheckInLongitude = request.Longitude,
                GpsAccuracyM = request.AccuracyMeters,
                Status = "Present",
                VerificationStatus = "Pending"
            };

            // Atomic insertion prevents simultaneous duplicate check-ins
            if (!MockAttendance.TryAdd(
                request.ShiftAssignmentId, attendance))
            {
                return Conflict(new
                {
                    message = "Attendance already recorded for this shift."
                });
            }

            return Ok(new
            {
                message = "Check-in recorded successfully using mock data.",
                distanceMeters = Math.Round(distance, 2),
                attendance
            });
        }

        // POST: api/Attendance/check-out
        [HttpPost("check-out")]
        public IActionResult CheckOut(
            [FromBody] CheckOutRequest request)
        {
            if (request.ShiftAssignmentId <= 0)
            {
                return BadRequest(new
                {
                    message = "Invalid shift assignment ID."
                });
            }

            // 1. Find attendance record
            if (!MockAttendance.TryGetValue(
                request.ShiftAssignmentId, out var attendance))
            {
                return NotFound(new
                {
                    message = "No check-in record found for this shift."
                });
            }

            // 2. Lock record to prevent simultaneous duplicate check-outs
            lock (attendance)
            {
                if (attendance.CheckOutAt.HasValue)
                {
                    return Conflict(new
                    {
                        message = "Check-out already recorded for this shift."
                    });
                }

                var checkOutTime = DateTime.UtcNow;

                // 3. Check-out must be after check-in
                if (!attendance.CheckInAt.HasValue ||
                    checkOutTime <= attendance.CheckInAt.Value)
                {
                    return BadRequest(new
                    {
                        message = "Check-out must be after check-in."
                    });
                }

                // 4. Record check-out using server time
                attendance.CheckOutAt = checkOutTime;

                return Ok(new
                {
                    message = "Check-out recorded successfully using mock data.",
                    attendance
                });
            }
        }

        // GET: api/Attendance/{shiftAssignmentId}
        [HttpGet("{shiftAssignmentId:int}")]
        public IActionResult GetAttendance(int shiftAssignmentId)
        {
            if (shiftAssignmentId <= 0)
            {
                return BadRequest(new
                {
                    message = "Invalid shift assignment ID."
                });
            }

            if (!MockAttendance.TryGetValue(
                shiftAssignmentId, out var attendance))
            {
                return NotFound(new
                {
                    message = "No attendance record found for this shift."
                });
            }

            return Ok(attendance);
        }
    }
}
