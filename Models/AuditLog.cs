namespace ShiftIQ.API.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
