
namespace ShiftIQ.API.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }

        public int CompanyId { get; set; }

        public string Name { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int GracePeriodMinutes { get; set; }

        public bool IsActive { get; set; }
    }
}
