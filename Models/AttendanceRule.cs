
namespace ShiftIQ.API.Models
{
    public class AttendanceRule
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;

        public int GraceMinutes { get; set; }

        public int EarlyWindowMinutes { get; set; }

        public int LateWindowMinutes { get; set; }

        public int AbsenceAfterMinutes { get; set; }

        public string? PointPolicy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
