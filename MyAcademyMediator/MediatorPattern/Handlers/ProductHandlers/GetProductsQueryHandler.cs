using Mapster;
using MediatR;
using MyAcademyMediator.MediatorPattern.Queries.ProductQueries;
using MyAcademyMediator.MediatorPattern.Results.ProductResults;
using MyAcademyMediator.Repositories.ProductRepository;

namespace MyAcademyMediator.MediatorPattern.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductsQuery, List<GetProductsQueryResult>>
    {
        public async Task<List<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var items = await _productRepository.GetAllAsync(x => x.Category);
            return items.Adapt<List<GetProductsQueryResult>>();

        }
    }
}
