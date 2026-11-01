using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Configurations
{
    public class AIInsightConfiguration : IEntityTypeConfiguration<AIInsight>
    {
        public void Configure(EntityTypeBuilder<AIInsight> builder)
        {
            // Table
            builder.ToTable("AIInsight");

            // Primary Key
            builder.HasKey(ai => ai.InsightId);

            // InsightId
            builder.Property(ai => ai.InsightId)
                .HasColumnName("insight_id");

            // Type
            builder.Property(ai => ai.Type)
                .HasColumnName("type")
                .HasMaxLength(50)
                .IsRequired();

            // Title
            builder.Property(ai => ai.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            // Description
            builder.Property(ai => ai.Description)
                .HasColumnName("description")
                .IsRequired();

            // ConfidenceScore
            builder.Property(ai => ai.ConfidenceScore)
                .HasColumnName("confidence_score")
                .HasColumnType("decimal(5,4)");

            // CreatedAt
            builder.Property(ai => ai.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            // CompanyId
            builder.Property(ai => ai.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();

            // EmployeeId
            builder.Property(ai => ai.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired(false);

            // Employee - AIInsight (One-to-Many, Optional)
            builder.HasOne(ai => ai.Employee)
                .WithMany(e => e.AIInsights)
                .HasForeignKey(ai => ai.EmployeeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}