using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class RewardConfiguration : IEntityTypeConfiguration<Reward>
    {
        public void Configure(EntityTypeBuilder<Reward> builder)
        {
            // Table
            builder.ToTable("Reward");

            // Primary Key
            builder.HasKey(r => r.RewardId);

            // RewardId
            builder.Property(r => r.RewardId)
                .HasColumnName("reward_id");

            // Name
            builder.Property(r => r.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            // Description
            builder.Property(r => r.Description)
                .HasColumnName("description")
                .IsRequired();

            // PointsRequired
            builder.Property(r => r.PointsRequired)
                .HasColumnName("points_required")
                .IsRequired();

            // IsActive
            builder.Property(r => r.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            // CreatedAt
            builder.Property(r => r.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // CompanyId
            builder.Property(r => r.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();
        }
    }
}