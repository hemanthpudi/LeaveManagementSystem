using LeaveManagementSystem.DTOs.Employee;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(CreateEmployeeDto employee);
        Task<Employee?> UpdateAsync(int id, UpdateEmployeeDto employee);
        Task<bool> DeleteAsync(int id);
    }
}
