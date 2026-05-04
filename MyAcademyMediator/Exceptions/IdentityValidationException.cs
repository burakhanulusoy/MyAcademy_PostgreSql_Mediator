using Microsoft.AspNetCore.Identity;

namespace MyAcademyMediator.Exceptions
{
    public class IdentityValidationException(IEnumerable<IdentityError> errors) : Exception("Kullanıcı işlemi hatası alındı!")
    {
        public IEnumerable<IdentityError> Errors { get; } = errors;
    }
}
