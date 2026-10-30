using System.ComponentModel.DataAnnotations;

namespace shiftIQ.API.DTOs
{
    public class CreateAttendanceCorrection
    {
        [Range(1, int.MaxValue)]
        public int AttendanceRecordId { get; set; }

        [Required]
        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;

        public DateTime? RequestedCheckInAt { get; set; }

        public DateTime? RequestedCheckOutAt { get; set; }
    }
}