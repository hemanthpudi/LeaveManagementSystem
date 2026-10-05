using LeaveManagementSystem.Data;
using LeaveManagementSystem.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repositories.RepositoryImpl
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}
