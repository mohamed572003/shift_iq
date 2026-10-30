using System.ComponentModel.DataAnnotations;

namespace shiftIQ.API.DTOs
{
    public class CheckInRequest
    {
        [Range(1, int.MaxValue)]
        public int EmployeeId { get; set; }

        [Range(1, int.MaxValue)]
        public int ShiftAssignmentId { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Range(0.1, 1000)]
        public double AccuracyMeters { get; set; }

        [Required]
        public string QrToken { get; set; } = string.Empty;

        [Required]
        public string DeviceId { get; set; } = string.Empty;
    }
}
