using System.ComponentModel.DataAnnotations;

namespace shiftIQ.API.DTOs
{
    public class ReviewLeaveRequest
    {
        [Range(1, int.MaxValue)]
        public int ApproverMembershipId { get; set; }

        [Required]
        public string Decision { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Comment { get; set; }
    }
}