
using Microsoft.EntityFrameworkCore;

using ShiftIQ.API.Models;

namespace shiftIQ.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
        public DbSet<ShiftAssignment> ShiftAssignments => Set<ShiftAssignment>();
        public DbSet<Shift> Shifts => Set<Shift>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Employee> Employees => Set<Employee>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
    .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<AttendanceRecord>()
                .HasKey(a => a.AttendanceId);

            modelBuilder.Entity<ShiftAssignment>()
                .HasKey(s => s.AssignmentId);

            modelBuilder.Entity<Shift>()
                .HasKey(s => s.ShiftId);

            modelBuilder.Entity<Branch>()
                .HasKey(b => b.BranchId);
        }
    }
}
