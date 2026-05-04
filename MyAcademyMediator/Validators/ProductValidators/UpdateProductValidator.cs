using FluentValidation;
using MyAcademyMediator.MediatorPattern.Commands.ProductCommands;

namespace MyAcademyMediator.Validators.ProductValidators
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Ürün adı boş geçilemez.")
               .MinimumLength(5).WithMessage("Ürün adı en az 5 karakter olmalıdır.")
               .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Ürün görselsiz olmaz, lütfen bir resim yolu belirtin.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.")
                .MinimumLength(10).WithMessage("Lütfen ürün hakkında biraz daha detay verin (en az 10 karakter).");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat bilgisi girilmelidir.")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stok adedi negatif bir değer olamaz.")
                .NotEmpty().WithMessage("Stok bilgisi girilmelidir.");
        }
    }
}
