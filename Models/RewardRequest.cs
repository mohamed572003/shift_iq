namespace ShiftIQ.API.Models
{
    public class RewardRequest
    {
        public int RewardRequestId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int RewardId { get; set; }
        public Reward Reward { get; set; }
        public string Status { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
