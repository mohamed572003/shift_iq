
namespace ShiftIQ.API.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Action { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;

        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
