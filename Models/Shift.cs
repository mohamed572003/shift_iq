using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int GracePeriodMinutes { get; set; }
        public bool IsActive { get; set; }
    }
}
