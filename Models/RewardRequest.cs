
namespace ShiftIQ.API.Models
{
    public class RewardRequest
    {
        public int RewardRequestId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int RewardId { get; set; }
        public Reward Reward { get; set; } = null!;

        public string Status { get; set; } = string.Empty;

        public DateTime RequestedAt { get; set; }
    }
}
