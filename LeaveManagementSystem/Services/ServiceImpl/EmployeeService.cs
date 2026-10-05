using LeaveManagementSystem.Data;
using LeaveManagementSystem.DTOs.Employee;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Services.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Employee> CreateAsync(CreateEmployeeDto employee)
        {
            var newEmployee = new Employee
            {
                EmployeeCode = employee.EmployeeCode,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                JoiningDate = employee.JoiningDate,
                IsActive = true
            };
            _unitOfWork.Employees.AddAsync(newEmployee);
            await _unitOfWork.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _unitOfWork.Employees.GetByIdAsync(id);
            if (emp==null)
            {
                return false;
            }
            _unitOfWork.Employees.Delete(emp);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task<Employee?> UpdateAsync(int id, UpdateEmployeeDto employee)
        {
            var emp = await _unitOfWork.Employees.GetByIdAsync(id);
            if (emp==null)
            {
                return null;
            }
            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Department = employee.Department;
            emp.JoiningDate = employee.JoiningDate;
            emp.IsActive = employee.IsActive;

            await _unitOfWork.SaveChangesAsync();
            return emp;
        }
    }
}
