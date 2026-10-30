
namespace ShiftIQ.API.Models
{
    public class ShiftAssignment
    {
        public int AssignmentId { get; set; }

        public int EmployeeId { get; set; }

        public int ShiftId { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }
    }
}
