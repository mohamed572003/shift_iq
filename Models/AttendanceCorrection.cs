
namespace ShiftIQ.API.Models
{
    public class AttendanceCorrection
    {
        public int CorrectionId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; } = null!;

        public DateTime? RequestedCheckIn { get; set; }
        public DateTime? RequestedCheckOut { get; set; }

        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? DecisionNote { get; set; }
    }
}
