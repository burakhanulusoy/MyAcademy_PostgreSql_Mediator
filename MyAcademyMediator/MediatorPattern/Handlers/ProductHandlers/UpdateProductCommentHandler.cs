using FluentValidation;
using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.Exceptions;
using MyAcademyMediator.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediator.Repositories.ProductRepository;

namespace MyAcademyMediator.MediatorPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommentHandler(IProductRepository _productRepository
                                            ,IValidator<UpdateProductCommand> _validator) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
            {
                throw new ApiValidationException(validationResult.Errors);
            }

            var mappedProduct = request.Adapt<Product>();

            await _productRepository.UpdateAsync(mappedProduct);
        }
    }
}
