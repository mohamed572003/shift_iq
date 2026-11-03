
using System.Collections.Generic;

namespace ShiftIQ.API.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public Employee? Employee { get; set; }

        public ICollection<Notification> Notifications { get; set; }
            = new List<Notification>();

        public ICollection<AuditLog> AuditLogs { get; set; }
            = new List<AuditLog>();
    }
}
