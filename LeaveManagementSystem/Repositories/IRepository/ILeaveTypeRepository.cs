using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repositories.IRepository
{
    public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
    {
        Task<LeaveType?> GetByNameAsync(string name);
    }
}
