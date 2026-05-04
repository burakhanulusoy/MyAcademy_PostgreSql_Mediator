using Microsoft.EntityFrameworkCore;
using MyAcademyMediator.Context;
using MyAcademyMediator.Entities;

namespace MyAcademyMediator.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext _context) : base(_context)
        {
        }

        public Task<List<Product>> GetProductsWithCategoryAsync()
        {
            return _table.Include(x => x.Category).AsNoTracking().ToListAsync();
        }




    }
}
