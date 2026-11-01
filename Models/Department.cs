using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
