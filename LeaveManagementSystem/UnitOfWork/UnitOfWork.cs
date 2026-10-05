using LeaveManagementSystem.Data;
using LeaveManagementSystem.Repositories.IRepository;

namespace LeaveManagementSystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IEmployeeRepository Employees { get; set; }

        public UnitOfWork(ApplicationDbContext context,
            IEmployeeRepository employees)
        {
            _context = context;
            Employees = employees;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
