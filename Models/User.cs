using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Status { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
