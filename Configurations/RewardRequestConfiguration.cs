using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class RewardRequestConfiguration : IEntityTypeConfiguration<RewardRequest>
    {
        public void Configure(EntityTypeBuilder<RewardRequest> builder)
        {
            // Table
            builder.ToTable("RewardRequest");

            // Primary Key
            builder.HasKey(rr => rr.RewardRequestId);

            // RewardRequestId
            builder.Property(rr => rr.RewardRequestId)
                .HasColumnName("reward_request_id");

            // Status
            builder.Property(rr => rr.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            // RequestedAt
            builder.Property(rr => rr.RequestedAt)
                .HasColumnName("requested_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // EmployeeId
            builder.Property(rr => rr.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // RewardId
            builder.Property(rr => rr.RewardId)
                .HasColumnName("reward_id")
                .IsRequired();

            // Employee - RewardRequest (One-to-Many)
            builder.HasOne(rr => rr.Employee)
                .WithMany(e => e.RewardRequests)
                .HasForeignKey(rr => rr.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Reward - RewardRequest (One-to-Many)
            builder.HasOne(rr => rr.Reward)
                .WithMany(r => r.RewardRequests)
                .HasForeignKey(rr => rr.RewardId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}