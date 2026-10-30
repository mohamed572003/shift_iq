
namespace ShiftIQ.API.Models
{
    public class Branch
    {
        public int BranchId { get; set; }

        public int CompanyId { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double GeofenceRadiusMeters { get; set; }

        public bool IsActive { get; set; }
    }
}
