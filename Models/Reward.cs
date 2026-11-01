using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class Reward
    {
        public int RewardId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Description { get; set; }
        public int PointsRequired { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public ICollection<RewardRequest> RewardRequests { get; set; } = new List<RewardRequest>();
    }
}
