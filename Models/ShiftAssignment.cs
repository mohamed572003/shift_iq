
using System.Collections.Generic;

namespace ShiftIQ.API.Models
{
    public class ShiftAssignment
    {
        public int AssignmentId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int ShiftId { get; set; }
        public Shift Shift { get; set; } = null!;

        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}

