using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediator.MediatorPattern.Results.CategoryResults;
using MyAcademyMediator.Repositories;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(IGenericRepository<Category> _genericRepository) : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var item = await _genericRepository.GetByIdAsync(request.Id);

            return item.Adapt<GetCategoryByIdQueryResult>();

        }
    }
}
