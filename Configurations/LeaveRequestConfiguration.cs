using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            // Table
            builder.ToTable("LeaveRequest");

            // Primary Key
            builder.HasKey(lr => lr.LeaveRequestId);

            // LeaveRequestId
            builder.Property(lr => lr.LeaveRequestId)
                .HasColumnName("leave_request_id");

            // StartDate
            builder.Property(lr => lr.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("date")
                .IsRequired();

            // EndDate
            builder.Property(lr => lr.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("date")
                .IsRequired();

            // Reason
            builder.Property(lr => lr.Reason)
                .HasColumnName("reason")
                .IsRequired();

            // Status
            builder.Property(lr => lr.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            // CreatedAt
            builder.Property(lr => lr.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // ReviewedBy
            builder.Property(lr => lr.ReviewedBy)
                .HasColumnName("reviewed_by")
                .IsRequired(false);

            // ReviewedAt
            builder.Property(lr => lr.ReviewedAt)
                .HasColumnName("reviewed_at")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // DecisionNote
            builder.Property(lr => lr.DecisionNote)
                .HasColumnName("decision_note")
                .IsRequired(false);

            // EmployeeId
            builder.Property(lr => lr.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // Employee - LeaveRequest (One-to-Many)
            builder.HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}