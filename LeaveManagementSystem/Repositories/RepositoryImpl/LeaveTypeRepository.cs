
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Repositories.IRepository;
using LeaveManagementSystem.Repositories.RepositoryImpl;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.API.Repositories;

public class LeaveTypeRepository
    : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<LeaveType?> GetByNameAsync(string name)
    {
        return await _dbset
            .FirstOrDefaultAsync(x =>
                x.LeaveTypeName == name);
    }
}