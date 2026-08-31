using MyAcademyMediator.Entities.Common;

namespace MyAcademyMediator.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task CreateAsync(TEntity entity);



    }
}
