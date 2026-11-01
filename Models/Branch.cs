namespace ShiftIQ.API.Models
{
    public class Branch
    {
        public int BranchId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal GeofenceRadiusMeters { get; set; }
        public bool IsActive { get; set; }
    }
}
