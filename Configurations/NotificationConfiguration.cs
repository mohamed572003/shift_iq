using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Table
            builder.ToTable("Notification");

            // Primary Key
            builder.HasKey(n => n.NotificationId);

            // NotificationId
            builder.Property(n => n.NotificationId)
                .HasColumnName("notification_id");

            // Title
            builder.Property(n => n.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            // Message
            builder.Property(n => n.Message)
                .HasColumnName("message")
                .IsRequired();

            // Type
            builder.Property(n => n.Type)
                .HasColumnName("type")
                .HasMaxLength(50)
                .IsRequired();

            // IsRead
            builder.Property(n => n.IsRead)
                .HasColumnName("is_read")
                .HasDefaultValue(false)
                .IsRequired();

            // CreatedAt
            builder.Property(n => n.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // UserId
            builder.Property(n => n.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            // User - Notification (One-to-Many)
            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}