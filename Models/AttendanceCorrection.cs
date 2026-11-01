namespace ShiftIQ.API.Models
{
    public class AttendanceCorrection
    {
        public int CorrectionId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }
        public DateTime? RequestedCheckIn { get; set; }
        public DateTime? RequestedCheckOut { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? DecisionNote { get; set; }
    }
}
