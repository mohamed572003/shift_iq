using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class TrustedDeviceConfiguration : IEntityTypeConfiguration<TrustedDevice>
    {
        public void Configure(EntityTypeBuilder<TrustedDevice> builder)
        {
            // Table
            builder.ToTable("TrustedDevice");

            // Primary Key
            builder.HasKey(td => td.DeviceId);

            // DeviceId
            builder.Property(td => td.DeviceId)
                .HasColumnName("device_id");

            // DeviceName
            builder.Property(td => td.DeviceName)
                .HasColumnName("device_name")
                .HasMaxLength(200)
                .IsRequired();

            // DeviceIdentifier
            builder.Property(td => td.DeviceIdentifier)
                .HasColumnName("device_identifier")
                .HasMaxLength(255)
                .IsRequired();

            // IsTrusted
            builder.Property(td => td.IsTrusted)
                .HasColumnName("is_trusted")
                .IsRequired();

            // CreatedAt
            builder.Property(td => td.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // LastUsedAt
            builder.Property(td => td.LastUsedAt)
                .HasColumnName("last_used_at")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // EmployeeId
            builder.Property(td => td.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // Employee - TrustedDevice (One-to-Many)
            builder.HasOne(td => td.Employee)
                .WithMany(e => e.TrustedDevices)
                .HasForeignKey(td => td.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}