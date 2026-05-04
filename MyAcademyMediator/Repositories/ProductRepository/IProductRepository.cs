using MyAcademyMediator.Entities;

namespace MyAcademyMediator.Repositories.ProductRepository
{
    public interface IProductRepository:IGenericRepository<Product>
    {

        Task<List<Product>> GetProductsWithCategoryAsync();

    }
}
