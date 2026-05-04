using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using MyAcademyMediator.Exceptions;

namespace MyAcademyMediator.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 1. Gelen hata FluentValidation hatası mı?
            if (context.Exception is ApiValidationException apiException)
            {
                foreach (var error in apiException.Errors)
                {
                    context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            // 2. Yoksa gelen hata senin yeni yazdığın Identity hatası mı?
            else if (context.Exception is IdentityValidationException identityException)
            {
                foreach (var error in identityException.Errors)
                {
                    // Identity hataları genel hata olduğu için propertyName kısmına string.Empty veriyoruz
                    context.ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // 3. İkisi de değilse (örneğin veritabanı bağlantı hatasıysa) filter bu işe karışmasın
            else
            {
                return; 
            }

            // Her iki durumda da sayfayı ve verileri geri döndürme standart işlemimiz çalışır
            var actionName = context.RouteData.Values["action"]?.ToString();
            var modelMetadataProvider = context.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();

            context.Result = new ViewResult
            {
                ViewName = actionName,
                ViewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState)
            };

            context.ExceptionHandled = true;
        }
    }
}