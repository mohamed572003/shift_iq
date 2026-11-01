using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class ShiftAssignmentConfiguration : IEntityTypeConfiguration<ShiftAssignment>
    {
        public void Configure(EntityTypeBuilder<ShiftAssignment> builder)
        {
            // Table
            builder.ToTable("ShiftAssignment");

            // Primary Key
            builder.HasKey(sa => sa.AssignmentId);

            // AssignmentId
            builder.Property(sa => sa.AssignmentId)
                .HasColumnName("assignment_id");

            // EffectiveFrom
            builder.Property(sa => sa.EffectiveFrom)
                .HasColumnName("effective_from")
                .HasColumnType("date")
                .IsRequired();

            // EffectiveTo
            builder.Property(sa => sa.EffectiveTo)
                .HasColumnName("effective_to")
                .HasColumnType("date")
                .IsRequired(false);

            // EmployeeId
            builder.Property(sa => sa.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // ShiftId
            builder.Property(sa => sa.ShiftId)
                .HasColumnName("shift_id")
                .IsRequired();

            // Employee - ShiftAssignment (One-to-Many)
            builder.HasOne(sa => sa.Employee)
                .WithMany(e => e.ShiftAssignments)
                .HasForeignKey(sa => sa.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Shift - ShiftAssignment (One-to-Many)
            builder.HasOne(sa => sa.Shift)
                .WithMany(s => s.ShiftAssignments)
                .HasForeignKey(sa => sa.ShiftId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}