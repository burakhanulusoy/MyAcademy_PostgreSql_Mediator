using FluentValidation;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;

namespace MyAcademyMediator.Validators.CategoryValidators
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("noooooo")
                                      .MaximumLength(10).WithMessage("kdas");

        }
    }
}
