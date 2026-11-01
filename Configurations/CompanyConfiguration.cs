using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;
namespace ShiftIQ.API.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Table
            builder.ToTable("Company");

            // Primary Key
            builder.HasKey(c => c.CompanyId);

            // CompanyId
            builder.Property(c => c.CompanyId)
                .HasColumnName("company_id");

            // Name
            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            // Status
            builder.Property(c => c.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            // CreatedAt
            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            // Relationships

            // Company - User (One-to-Many)
            builder.HasMany(c => c.Users)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            // Company - Branch (One-to-Many)
            builder.HasMany(c => c.Branches)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            // Company - Shift (One-to-Many)
            builder.HasMany(c => c.Shifts)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            // Company - Reward (One-to-Many)
            builder.HasMany(c => c.Rewards)
                .WithOne(r => r.Company)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            // Company - AIInsight (One-to-Many)
            builder.HasMany(c => c.AIInsights)
                .WithOne(ai => ai.Company)
                .HasForeignKey(ai => ai.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
