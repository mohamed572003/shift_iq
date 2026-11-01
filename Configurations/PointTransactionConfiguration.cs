using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class PointTransactionConfiguration : IEntityTypeConfiguration<PointTransaction>
    {
        public void Configure(EntityTypeBuilder<PointTransaction> builder)
        {
            // Table
            builder.ToTable("PointTransaction");

            // Primary Key
            builder.HasKey(pt => pt.TransactionId);

            // TransactionId
            builder.Property(pt => pt.TransactionId)
                .HasColumnName("transaction_id");

            // Points
            builder.Property(pt => pt.Points)
                .HasColumnName("points")
                .IsRequired();

            // TransactionType
            builder.Property(pt => pt.TransactionType)
                .HasColumnName("transaction_type")
                .HasMaxLength(50)
                .IsRequired();

            // Reason
            builder.Property(pt => pt.Reason)
                .HasColumnName("reason")
                .IsRequired();

            // CreatedAt
            builder.Property(pt => pt.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // EmployeeId
            builder.Property(pt => pt.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // Employee - PointTransaction (One-to-Many)
            builder.HasOne(pt => pt.Employee)
                .WithMany(e => e.PointTransactions)
                .HasForeignKey(pt => pt.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}