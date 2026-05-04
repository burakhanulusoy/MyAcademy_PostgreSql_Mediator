using MediatR;
using MyAcademyMediator.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediator.Repositories.ProductRepository;
using MyAcademyMediator.UOW;

namespace MyAcademyMediator.MediatorPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(IProductRepository _productRepository,
                                              IUnitOfWork _unitOfWork) : IRequestHandler<RemoveProductCommand>
    {
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {

            await _productRepository.DeleteAsync(request.Id);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}