using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();
        public ICollection<TrustedDevice> TrustedDevices { get; set; } = new List<TrustedDevice>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public ICollection<AttendanceCorrection> AttendanceCorrections
        { get; set; } = new List<AttendanceCorrection>();
        public ICollection<PointTransaction> PointTransactions
        { get; set; } = new List<PointTransaction>();
        public ICollection<RewardRequest> RewardRequests
        { get; set; } = new List<RewardRequest>();
        public ICollection<AIInsight> AIInsights { get; set; } = new List<AIInsight>();
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string EmployeeNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime HiredOn { get; set; }
    }
}
