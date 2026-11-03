
namespace ShiftIQ.API.Models
{
    public class AIInsight
    {
        public int InsightId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? ConfidenceScore { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
