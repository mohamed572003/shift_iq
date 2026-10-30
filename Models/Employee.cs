
namespace ShiftIQ.API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }

        public int UserId { get; set; }

        public string EmployeeNumber { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime HiredOn { get; set; }
    }
}
