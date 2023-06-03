using HrManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories
{
    public abstract class BaseRepository<BaseEntity> : IDisposable, IBaseRepository<BaseEntity> where BaseEntity : class
    {
        private readonly HrManagementContext _context;

        protected BaseRepository(DbContextOptions<HrManagementContext> contextOptions)
        {
            _context = new HrManagementContext(contextOptions);
        }

        public async Task<bool> CreateAsync(BaseEntity entity)
        {
            await _context.Set<BaseEntity>().AddAsync(entity);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteAsync(BaseEntity entity)
        {
            _context.Set<BaseEntity>().Attach(entity);
            _context.Set<BaseEntity>().Remove(entity);
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

        public IEnumerable<BaseEntity> ReadAll()
        {
            return _context.Set<BaseEntity>().AsNoTracking().ToList();
        }

        public async Task<BaseEntity> ReadByIdAsync(int id)
        {
            return await _context.Set<BaseEntity>().FindAsync(id);
        }

        public async Task<BaseEntity> ReadByIdAsync(Guid id)
        {
            return await _context.Set<BaseEntity>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(BaseEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
