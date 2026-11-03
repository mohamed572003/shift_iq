
using System.Collections.Generic;

namespace ShiftIQ.API.Models
{
    public class Reward
    {
        public int RewardId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public string Description { get; set; } = string.Empty;
        public int PointsRequired { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<RewardRequest> RewardRequests { get; set; }
            = new List<RewardRequest>();
    }
}
