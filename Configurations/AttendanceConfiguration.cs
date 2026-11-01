using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // Table
            builder.ToTable("Attendance");

            // Primary Key
            builder.HasKey(a => a.AttendanceId);

            // AttendanceId
            builder.Property(a => a.AttendanceId)
                .HasColumnName("attendance_id");

            // ShiftAssignmentId
            builder.Property(a => a.ShiftAssignmentId)
                .HasColumnName("shift_assignment_id")
                .IsRequired();

            // CheckInAt
            builder.Property(a => a.CheckInAt)
                .HasColumnName("check_in_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // CheckOutAt
            builder.Property(a => a.CheckOutAt)
                .HasColumnName("check_out_at")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // CheckInLatitude
            builder.Property(a => a.CheckInLatitude)
                .HasColumnName("check_in_latitude")
                .HasColumnType("decimal(9,6)");

            // CheckInLongitude
            builder.Property(a => a.CheckInLongitude)
                .HasColumnName("check_in_longitude")
                .HasColumnType("decimal(9,6)");

            // Status
            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasMaxLength(50);

            // GpsAccuracyM
            builder.Property(a => a.GpsAccuracyM)
                .HasColumnName("gps_accuracy_m")
                .HasColumnType("decimal(10,2)");

            // VerificationStatus
            builder.Property(a => a.VerificationStatus)
                .HasColumnName("verification_status")
                .HasMaxLength(50);

            // ShiftAssignment - Attendance (One-to-Many)
            builder.HasOne(a => a.ShiftAssignment)
                .WithMany(sa => sa.Attendances)
                .HasForeignKey(a => a.ShiftAssignmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}