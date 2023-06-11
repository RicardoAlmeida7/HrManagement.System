using HrManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private readonly HrManagementContext _context;

        protected BaseRepository(DbContextOptions<HrManagementContext> contextOptions)
        {
            _context = new HrManagementContext(contextOptions);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T> ReadByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id); 
        }

        public async Task<T> ReadByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Update(entity);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
