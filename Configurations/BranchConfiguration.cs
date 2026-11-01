using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            // Table
            builder.ToTable("Branch");

            // Primary Key
            builder.HasKey(b => b.BranchId);

            // BranchId
            builder.Property(b => b.BranchId)
                .HasColumnName("branch_id");

            // Name
            builder.Property(b => b.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            // Latitude
            builder.Property(b => b.Latitude)
                .HasColumnName("latitude")
                .HasColumnType("decimal(9,6)");

            // Longitude
            builder.Property(b => b.Longitude)
                .HasColumnName("longitude")
                .HasColumnType("decimal(9,6)");

            // GeofenceRadiusMeters
            builder.Property(b => b.GeofenceRadiusMeters)
                .HasColumnName("geofence_radius_meters")
                .HasColumnType("decimal(10,2)");

            // IsActive
            builder.Property(b => b.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            // CompanyId
            builder.Property(b => b.CompanyId)
                .HasColumnName("company_id");
        }
    }
}