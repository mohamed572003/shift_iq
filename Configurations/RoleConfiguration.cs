using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Table
            builder.ToTable("Role");

            // Primary Key
            builder.HasKey(r => r.RoleId);

            // RoleId
            builder.Property(r => r.RoleId)
                .HasColumnName("role_id");

            // Name
            builder.Property(r => r.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            // Unique Constraint
            builder.HasIndex(r => r.Name)
                .IsUnique();


            //Relationship

            // Role - User (One-to-Many)
            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}