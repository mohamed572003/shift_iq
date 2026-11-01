using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            // Table
            builder.ToTable("AuditLog");

            // Primary Key
            builder.HasKey(al => al.AuditLogId);

            // AuditLogId
            builder.Property(al => al.AuditLogId)
                .HasColumnName("audit_log_id");

            // Action
            builder.Property(al => al.Action)
                .HasColumnName("action")
                .HasMaxLength(100)
                .IsRequired();

            // EntityType
            builder.Property(al => al.EntityType)
                .HasColumnName("entity_type")
                .HasMaxLength(100)
                .IsRequired();

            // EntityId
            builder.Property(al => al.EntityId)
                .HasColumnName("entity_id")
                .HasMaxLength(128)
                .IsRequired();

            // Details
            builder.Property(al => al.Details)
                .HasColumnName("details")
                .IsRequired();

            // CreatedAt
            builder.Property(al => al.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // UserId
            builder.Property(al => al.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            // User - AuditLog (One-to-Many)
            builder.HasOne(al => al.User)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}