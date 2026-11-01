using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("User");

            // Primary Key
            builder.HasKey(u => u.UserId);

            // UserId
            builder.Property(u => u.UserId)
                .HasColumnName("user_id");

            // FullName
            builder.Property(u => u.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(200)
                .IsRequired();

            // Email
            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(320)
                .IsRequired();

            // Unique Email
            builder.HasIndex(u => u.Email)
                .IsUnique();

            // PasswordHash
            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(255)
                .IsRequired();

            // Status
            builder.Property(u => u.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            // CompanyId
            builder.Property(u => u.CompanyId)
                .HasColumnName("company_id");

            // RoleId
            builder.Property(u => u.RoleId)
                .HasColumnName("role_id");
        }
    }
}