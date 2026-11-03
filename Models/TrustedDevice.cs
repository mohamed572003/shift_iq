
namespace ShiftIQ.API.Models
{
    public class TrustedDevice
    {
        public int DeviceId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public string DeviceName { get; set; } = string.Empty;
        public string DeviceIdentifier { get; set; } = string.Empty;

        public bool IsTrusted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
    }
}
