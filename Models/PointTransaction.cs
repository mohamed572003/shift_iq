namespace ShiftIQ.API.Models
{
    public class PointTransaction
    {
        public int TransactionId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Points { get; set; }
        public string TransactionType { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
