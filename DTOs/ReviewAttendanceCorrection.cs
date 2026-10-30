using System.ComponentModel.DataAnnotations;

namespace shiftIQ.API.DTOs
{
    public class ReviewAttendanceCorrection
    {
        [Range(1, int.MaxValue)]
        public int ReviewedByMembershipId { get; set; }

        [Required]
        public string Decision { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ReviewNote { get; set; }
    }
}