using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MyAcademyMediator.Exceptions;

namespace MyAcademyMediator.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not ApiValidationException validationException)
            {
                return;
            }

            // FluentValidation'ın kendi listesinde dönüyoruz
            foreach (var error in validationException.Errors)
            {
                context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            var actionName = context.RouteData.Values["action"]?.ToString();

            // ASP.NET Core'da Controller'a doğrudan erişim olmadığı için,
            // sistemdeki mevcut ModelState'i kullanarak ViewData'yı kendimiz inşa ediyoruz.
            var modelMetadataProvider = context.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();

            context.Result = new ViewResult
            {
                ViewName = actionName,
                // Hem kullanıcının girdiği form verileri hem de eklediğimiz hatalar View'a taşınmış oluyor
                ViewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState)
            };

            context.ExceptionHandled = true;
        }
    }
}