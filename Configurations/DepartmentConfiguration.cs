using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table
            builder.ToTable("Department");

            // Primary Key
            builder.HasKey(d => d.DepartmentId);

            // DepartmentId
            builder.Property(d => d.DepartmentId)
                .HasColumnName("department_id");

            // Name
            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            // BranchId
            builder.Property(d => d.BranchId)
                .HasColumnName("branch_id");

            // Branch - Department (One-to-Many)
            builder.HasOne(d => d.Branch)
                .WithMany(b => b.Departments)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}