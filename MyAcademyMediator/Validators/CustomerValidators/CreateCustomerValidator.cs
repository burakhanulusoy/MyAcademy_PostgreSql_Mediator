using FluentValidation;
using MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;

namespace MyAcademyMediator.Validators.CustomerValidators
{
    public class CreateCustomerValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {


            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad soyad alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad soyad en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Şehir en fazla 30 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                .Matches(@"^0?5\d{9}$")
                .WithMessage("Geçerli bir telefon numarası giriniz. Örnek: 05321234567");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Adres en az 10 karakter olmalıdır.")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olabilir.");


        }
    }
}
