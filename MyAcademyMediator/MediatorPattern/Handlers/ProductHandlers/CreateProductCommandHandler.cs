using FluentValidation;
using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.Exceptions;
using MyAcademyMediator.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediator.Repositories.ProductRepository;
using MyAcademyMediator.UOW;

namespace MyAcademyMediator.MediatorPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(IProductRepository _productRepository
                                            ,IValidator<CreateProductCommand> _validator
                                            ,IUnitOfWork _unitOfWork) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {

                throw new ApiValidationException(validationResult.Errors);
            }



            var mappedProdcut = request.Adapt<Product>();

            await _productRepository.CreateAsync(mappedProdcut);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
