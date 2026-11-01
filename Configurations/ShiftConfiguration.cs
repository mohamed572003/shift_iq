using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            // Table
            builder.ToTable("Shift");

            // Primary Key
            builder.HasKey(s => s.ShiftId);

            // ShiftId
            builder.Property(s => s.ShiftId)
                .HasColumnName("shift_id");

            // Name
            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            // StartTime
            builder.Property(s => s.StartTime)
                .HasColumnName("start_time")
                .HasColumnType("time")
                .IsRequired();

            // EndTime
            builder.Property(s => s.EndTime)
                .HasColumnName("end_time")
                .HasColumnType("time")
                .IsRequired();

            // GracePeriodMinutes
            builder.Property(s => s.GracePeriodMinutes)
                .HasColumnName("grace_period_minutes")
                .HasDefaultValue(0)
                .IsRequired();

            // IsActive
            builder.Property(s => s.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

            // CompanyId
            builder.Property(s => s.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();
        }
    }
}