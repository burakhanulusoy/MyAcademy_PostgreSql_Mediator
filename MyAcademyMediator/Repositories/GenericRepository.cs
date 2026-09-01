using Microsoft.EntityFrameworkCore;
using MyAcademyMediator.Context;
using MyAcademyMediator.Entities.Common;
using System.Linq.Expressions;

namespace MyAcademyMediator.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext _context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly DbSet<TEntity> _table=_context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _table.FindAsync(id);
            _context.Remove(result);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().OrderBy(x=>x.CreatedAt).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _table.AsNoTracking().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.OrderBy(x => x.CreatedAt).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);

        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
