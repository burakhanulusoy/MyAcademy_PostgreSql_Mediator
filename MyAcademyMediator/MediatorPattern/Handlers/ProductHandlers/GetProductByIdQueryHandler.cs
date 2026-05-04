using Mapster;
using MediatR;
using MyAcademyMediator.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediator.MediatorPattern.Results.ProductResults;
using MyAcademyMediator.Repositories.ProductRepository;

namespace MyAcademyMediator.MediatorPattern.Handlers.ProductHandlers;

public class GetProductByIdQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {

        var item = await _productRepository.GetByIdAsync(request.Id);

        return item.Adapt<GetProductByIdQueryResult>();



    }
}
