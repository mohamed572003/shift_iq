using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int ShiftAssignmentId { get; set; }
        public ShiftAssignment ShiftAssignment { get; set; }
        public ICollection<AttendanceCorrection> AttendanceCorrections
        { get; set; } = new List<AttendanceCorrection>();
        public DateTime CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public decimal CheckInLatitude { get; set; }
        public decimal CheckInLongitude { get; set; }
        public string Status { get; set; }
        public decimal GpsAccuracyM { get; set; }
        public string VerificationStatus { get; set; }
    }
}
