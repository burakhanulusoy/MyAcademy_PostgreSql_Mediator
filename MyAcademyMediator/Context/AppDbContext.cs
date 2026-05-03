using Microsoft.EntityFrameworkCore;
using MyAcademyMediator.Entities;

namespace MyAcademyMediator.Context
{
    public class AppDbContext(DbContextOptions options):DbContext(options)
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



    }
}
