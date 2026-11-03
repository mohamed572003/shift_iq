
namespace ShiftIQ.API.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
