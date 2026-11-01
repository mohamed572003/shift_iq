namespace ShiftIQ.API.Models
{
    public class AIInsight
    {
        public int InsightId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? ConfidenceScore { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
