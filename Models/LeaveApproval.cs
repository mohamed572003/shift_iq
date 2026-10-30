namespace ShiftIQ.API.Models
{
    public class LeaveApproval
    {
        public int Id { get; set; }
        public int LeaveRequestId { get; set; }
        public int ApproverMembershipId { get; set; }
        public DateTime? DecidedAt { get; set; }
        public string? Comment { get; set; }
        public string Decision { get; set; } = "Pending";
    }
}