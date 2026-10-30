
namespace ShiftIQ.API.Models
{
    public class AttendanceRecord
    {
        public int AttendanceId { get; set; }

        public int ShiftAssignmentId { get; set; }

        public DateTime? CheckInAt { get; set; }

        public DateTime? CheckOutAt { get; set; }

        public double? CheckInLatitude { get; set; }

        public double? CheckInLongitude { get; set; }

        public string Status { get; set; } = string.Empty;

        public double? GpsAccuracyM { get; set; }

        public string VerificationStatus { get; set; } = string.Empty;
    }
}
