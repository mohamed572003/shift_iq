using Microsoft.EntityFrameworkCore;
using ShiftIQ.API.Models;

namespace ShiftIQ.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftAssignment> ShiftAssignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<TrustedDevice> TrustedDevices { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<AttendanceCorrection> AttendanceCorrections { get; set; }
        public DbSet<PointTransaction> PointTransactions { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<RewardRequest> RewardRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AIInsight> AIInsights { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly
            );
        }
    }
    } 
