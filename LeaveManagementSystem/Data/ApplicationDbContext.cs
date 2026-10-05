using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeCode).IsRequired();
                entity.HasIndex(e => e.EmployeeCode).IsUnique();
                entity.Property(e=>e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Department).IsRequired();
                entity.Property(e=>e.IsActive).HasDefaultValue(true);
            });
            modelBuilder.Entity<LeaveType>(entity=>
            {
                entity.HasKey(l => l.LeaveTypeId);
                entity.Property(l => l.LeaveTypeName).IsRequired();
                entity.Property(l => l.LeaveTypeName).IsRequired();
                entity.Property(l => l.MaximumDays).IsRequired();
                entity.Property(l => l.IsActive).HasDefaultValue(true);
            });
            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.HasKey(l => l.LeaveRequestId);
                entity.Property(l => l.Reason).IsRequired();
                entity.Property(l => l.Status).IsRequired();
                entity.Property(l => l.AppliedDate).IsRequired();
                entity.HasOne(l => l.Employee)
                    .WithMany(e => e.LeaveRequests)
                    .HasForeignKey(l => l.EmployeeId);
                entity.HasOne(l => l.LeaveType)
                    .WithMany(lt => lt.LeaveRequests)
                    .HasForeignKey(l => l.LeaveTypeId);
            });
            modelBuilder.Entity<LeaveBalance>(entity =>
            {
                entity.HasKey(l => l.LeaveBalanceId);
                entity.Property(l=>l.TotalDays).IsRequired();
                entity.Property(l => l.UsedDays).HasDefaultValue(0);
                entity.HasOne(l => l.Employee)
                    .WithMany(e => e.LeaveBalances)
                    .HasForeignKey(l => l.EmployeeId);
                entity.HasOne(l => l.LeaveType)
                    .WithMany(lt => lt.LeaveBalances)
                    .HasForeignKey(l => l.LeaveTypeId);
            });

            //Seeding Employee data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeCode = "EMP001",
                    Name = "Hemanth Pudi",
                    Email = "hemanth@example.com",
                    Department = "IT",
                    JoiningDate = new DateTime(2024, 1, 15),
                    IsActive = true
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeCode = "EMP002",
                    Name = "Pradeep Savara",
                    Email = "pradeep@example.com",
                    Department = "HR",
                    JoiningDate = new DateTime(2023, 6, 10),
                    IsActive = true
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeCode = "EMP003",
                    Name = "Arjun Reddy",
                    Email = "arjun@example.com",
                    Department = "Finance",
                    JoiningDate = new DateTime(2024, 3, 20),
                    IsActive = true
                }
            );

            //Seeding LeaveType data
            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType
                {
                    LeaveTypeId = 1,
                    LeaveTypeName = "Casual Leave",
                    MaximumDays = 12,
                    IsActive = true
                },
                new LeaveType
                {
                    LeaveTypeId = 2,
                    LeaveTypeName = "Sick Leave",
                    MaximumDays = 10,
                    IsActive = true
                },
                new LeaveType
                {
                    LeaveTypeId = 3,
                    LeaveTypeName = "Earned Leave",
                    MaximumDays = 15,
                    IsActive = true
                }
            );
          
            //Seeding LeaveBalance data
            modelBuilder.Entity<LeaveBalance>().HasData(
                // Hemanth
                new LeaveBalance
                {
                    LeaveBalanceId = 1,
                    EmployeeId = 1,
                    LeaveTypeId = 1,
                    TotalDays = 12,
                    UsedDays = 0
                },
                new LeaveBalance
                {
                    LeaveBalanceId = 2,
                    EmployeeId = 1,
                    LeaveTypeId = 2,
                    TotalDays = 10,
                    UsedDays = 0
                },
                new LeaveBalance
                {
                    LeaveBalanceId = 3,
                    EmployeeId = 1,
                    LeaveTypeId = 3,
                    TotalDays = 15,
                    UsedDays = 0
                },

                // Pradeep
                new LeaveBalance
                {
                    LeaveBalanceId = 4,
                    EmployeeId = 2,
                    LeaveTypeId = 1,
                    TotalDays = 12,
                    UsedDays = 0
                },
                new LeaveBalance
                {
                    LeaveBalanceId = 5,
                    EmployeeId = 2,
                    LeaveTypeId = 2,
                    TotalDays = 10,
                    UsedDays = 0
                },
                new LeaveBalance
                {
                    LeaveBalanceId = 6,
                    EmployeeId = 2,
                    LeaveTypeId = 3,
                    TotalDays = 15,
                    UsedDays = 0
                },

                // Arjun
                new LeaveBalance
                {
                    LeaveBalanceId = 7,
                    EmployeeId = 3,
                    LeaveTypeId = 1,
                    TotalDays = 12,
                    UsedDays = 0
                },
                new LeaveBalance
                {
                    LeaveBalanceId = 8,
                    EmployeeId = 3,
                    LeaveTypeId = 2,
                    TotalDays = 10,
                    UsedDays = 0
                },
                new LeaveBalance
                {
                    LeaveBalanceId = 9,
                    EmployeeId = 3,
                    LeaveTypeId = 3,
                    TotalDays = 15,
                    UsedDays = 0
                }
            );
        }

    }
}
