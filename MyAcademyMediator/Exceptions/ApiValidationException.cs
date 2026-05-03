using FluentValidation.Results;

namespace MyAcademyMediator.Exceptions
{
    public class ApiValidationException(IEnumerable<ValidationFailure> errors) : Exception("Validasyon hatası alındı!")
    {
        public IEnumerable<ValidationFailure> Errors { get; } = errors;

    }
}
