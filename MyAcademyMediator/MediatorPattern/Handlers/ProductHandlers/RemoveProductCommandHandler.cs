using MediatR;
using MyAcademyMediator.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediator.Repositories.ProductRepository;

namespace MyAcademyMediator.MediatorPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(IProductRepository _productRepository) : IRequestHandler<RemoveProductCommand>
    {
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {

            await _productRepository.DeleteAsync(request.Id);

        }
    }
}