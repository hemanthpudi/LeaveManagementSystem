using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repositories.IRepository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        Task<Employee?> GetByEmployeeCodeAsync(string employeeCode);
        Task<Employee?> GetByEmailAsync(string email);
    }
}
