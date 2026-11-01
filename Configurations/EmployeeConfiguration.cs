using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table
            builder.ToTable("Employee");

            // Primary Key
            builder.HasKey(e => e.EmployeeId);

            // EmployeeId
            builder.Property(e => e.EmployeeId)
                .HasColumnName("employee_id");

            // EmployeeNumber
            builder.Property(e => e.EmployeeNumber)
                .HasColumnName("employee_number")
                .HasMaxLength(50)
                .IsRequired();

            // JobTitle
            builder.Property(e => e.JobTitle)
                .HasColumnName("job_title")
                .HasMaxLength(200)
                .IsRequired();

            // Status
            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            // HiredOn
            builder.Property(e => e.HiredOn)
                .HasColumnName("hired_on")
                .HasColumnType("date")
                .IsRequired();

            // DepartmentId
            builder.Property(e => e.DepartmentId)
                .HasColumnName("department_id");

            // UserId
            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            // Unique UserId (One-to-One)
            builder.HasIndex(e => e.UserId)
                .IsUnique();
             //Rel

            // Employee - Department (Many-to-One)
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Employee - User (One-to-One)
            builder.HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}