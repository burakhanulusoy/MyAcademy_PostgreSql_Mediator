using Microsoft.EntityFrameworkCore;
using MyAcademyMediator.Entities;
using MyAcademyMediator.Entities.Common;
using System.Linq.Expressions;

namespace MyAcademyMediator.Context
{
    public class AppDbContext(DbContextOptions options):DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            foreach (var entitiyType in modelBuilder.Model.GetEntityTypes())
            {

                if (typeof(BaseEntity).IsAssignableFrom(entitiyType.ClrType))
                {
                    //SOFT DELETE YAPMAK İÇİN SİLİNENLERİ GETİRMEYİ ENGELLEMEK İÇİN QUERY FILTER KULLANACAĞIZ
                    //wrapper yapıyoruz, yani sorgulara otomatik olarak silinmiş olanları getirme filtresi ekliyoruz
                    //select * from table where IsDeleted = false olanlar gelsin sadece diyeceğiz
                    modelBuilder.Entity(entitiyType.ClrType)
                                .HasQueryFilter(ConvertToDeleteFilter(entitiyType.ClrType));

                }

            }
        }


        private static LambdaExpression ConvertToDeleteFilter(Type type)
        {

            var parameter = Expression.Parameter(type, "e");

            var property = Expression.Property(Expression.Convert(parameter, typeof(BaseEntity)), "IsDeleted");

            var notDeleted = Expression.Not(property);

            return Expression.Lambda(notDeleted, parameter);



        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}
