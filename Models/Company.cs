
using System.Collections.Generic;

namespace ShiftIQ.API.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
        public ICollection<Reward> Rewards { get; set; } = new List<Reward>();
        public ICollection<AIInsight> AIInsights { get; set; } = new List<AIInsight>();
    }
}
