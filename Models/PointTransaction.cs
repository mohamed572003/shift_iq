
namespace ShiftIQ.API.Models
{
    public class PointTransaction
    {
        public int TransactionId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int Points { get; set; }

        public string TransactionType { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
