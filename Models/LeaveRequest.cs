
namespace ShiftIQ.API.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? DecisionNote { get; set; }
    }
}
