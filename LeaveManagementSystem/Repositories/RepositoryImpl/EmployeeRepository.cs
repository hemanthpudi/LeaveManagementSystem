using LeaveManagementSystem.Repositories.IRepository;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repositories.RepositoryImpl
{
    public class EmployeeRepository
        : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context)
            : base(context)
    {
    }

        public async Task<Employee?> GetByEmployeeCodeAsync(
            string employeeCode)
        {
            return await _dbset
                .FirstOrDefaultAsync(e =>
                    e.EmployeeCode == employeeCode);
        }

        public async Task<Employee?> GetByEmailAsync(
            string email)
        {
            return await _dbset
                .FirstOrDefaultAsync(e =>
                    e.Email == email);
        }
    }
}   