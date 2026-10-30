
using System.ComponentModel.DataAnnotations;

namespace shiftIQ.API.DTOs
{
    public class CheckOutRequest
    {
        [Range(1, int.MaxValue)]
        public int ShiftAssignmentId { get; set; }
    }
}
