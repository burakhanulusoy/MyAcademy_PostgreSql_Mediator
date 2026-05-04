using FluentValidation;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;

namespace MyAcademyMediator.Validators.CategoryValidators
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş geçilemez!")
                .MinimumLength(5).WithMessage("Kategori adı en az 5 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır.");
        }
    }
}
