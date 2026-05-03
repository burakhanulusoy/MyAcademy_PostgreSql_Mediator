using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediator.MediatorPattern.Results.CategoryResults;
using MyAcademyMediator.Repositories;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler(IGenericRepository<Category> _genericRepository) : IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
    {
        public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {

            var items = await _genericRepository.GetAllAsync();

            return items.Adapt<List<GetCategoriesQueryResult>>();



        }
    }
}
