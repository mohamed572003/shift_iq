using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class AttendanceCorrectionConfiguration : IEntityTypeConfiguration<AttendanceCorrection>
    {
        public void Configure(EntityTypeBuilder<AttendanceCorrection> builder)
        {
            // Table
            builder.ToTable("AttendanceCorrection");

            // Primary Key
            builder.HasKey(ac => ac.CorrectionId);

            // CorrectionId
            builder.Property(ac => ac.CorrectionId)
                .HasColumnName("correction_id");

            // RequestedCheckIn
            builder.Property(ac => ac.RequestedCheckIn)
                .HasColumnName("requested_check_in")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // RequestedCheckOut
            builder.Property(ac => ac.RequestedCheckOut)
                .HasColumnName("requested_check_out")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // Reason
            builder.Property(ac => ac.Reason)
                .HasColumnName("reason")
                .IsRequired();

            // Status
            builder.Property(ac => ac.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            // CreatedAt
            builder.Property(ac => ac.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // ReviewedBy
            builder.Property(ac => ac.ReviewedBy)
                .HasColumnName("reviewed_by")
                .IsRequired(false);

            // ReviewedAt
            builder.Property(ac => ac.ReviewedAt)
                .HasColumnName("reviewed_at")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // DecisionNote
            builder.Property(ac => ac.DecisionNote)
                .HasColumnName("decision_note")
                .IsRequired(false);

            // EmployeeId
            builder.Property(ac => ac.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // AttendanceId
            builder.Property(ac => ac.AttendanceId)
                .HasColumnName("attendance_id")
                .IsRequired();

            // Employee - AttendanceCorrection (One-to-Many)
            builder.HasOne(ac => ac.Employee)
                .WithMany(e => e.AttendanceCorrections)
                .HasForeignKey(ac => ac.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Attendance - AttendanceCorrection (One-to-Many)
            builder.HasOne(ac => ac.Attendance)
                .WithMany(a => a.AttendanceCorrections)
                .HasForeignKey(ac => ac.AttendanceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}