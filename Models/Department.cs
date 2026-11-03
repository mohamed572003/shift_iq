
using System.Collections.Generic;

namespace ShiftIQ.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }

        public Branch Branch { get; set; } = null!;

        public string Name { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}
