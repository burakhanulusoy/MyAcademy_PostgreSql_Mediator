using MyAcademyMediator.Entities.Common;
using System.Linq.Expressions;

namespace MyAcademyMediator.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task CreateAsync(TEntity entity);



    }
}
