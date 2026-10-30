
namespace ShiftIQ.API.Models
{
    public class WorkLocation
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int? BranchId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double GeofenceRadiusM { get; set; }

        public bool IsActive { get; set; } = true;

        public string? TimeZone { get; set; }
    }
}
