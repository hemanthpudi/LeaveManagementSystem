using LeaveManagementSystem.Repositories.IRepository;

namespace LeaveManagementSystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; set; }
        Task<int> SaveChangesAsync();
    }
}
