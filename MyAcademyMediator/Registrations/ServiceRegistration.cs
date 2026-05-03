using Microsoft.EntityFrameworkCore;
using MyAcademyMediator.Context;
using MyAcademyMediator.Interceptors;
using MyAcademyMediator.Repositories;
using System.Reflection;
using FluentValidation;


namespace MyAcademyMediator.Registrations
{
    public static class ServiceRegistration 
    {

        public static void AddServiceRegistrationExt(this IServiceCollection services,IConfiguration configuration)
        {

            //Context Registration

            services.AddDbContext<AppDbContext>(options =>
            {
                options.AddInterceptors(new AuditDbContextInterceptor());
                options.UseNpgsql(configuration.GetConnectionString("PostqreSql"));

            });

           
            
            //GenericRepository  <> işarteinin nedeni iiçe sürekli entity giriş cısıkıc var degısyor olduğu için :)

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));




            //Mediator Registration

            services.AddMediatR(options =>
            {
                //içinde bulundugun katmanda olan tum handlerın registration işleminı yapıyor
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //nereden bilecek dersen IRequestHandler ile handlerları işaretledik oradan tanıyaacak

            });


            //validasyon registration
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        }



    }
}
