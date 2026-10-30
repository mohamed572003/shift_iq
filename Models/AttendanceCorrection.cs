
namespace ShiftIQ.API.Models
{
    public class AttendanceCorrection
    {
        public int Id { get; set; }

        public int AttendanceRecordId { get; set; }

        public string Reason { get; set; } = string.Empty;

        public DateTime? RequestedCheckInAt { get; set; }

        public DateTime? RequestedCheckOutAt { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestedAt { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public int? ReviewedByMembershipId { get; set; }

        public string? ReviewNote { get; set; }
    }
}
