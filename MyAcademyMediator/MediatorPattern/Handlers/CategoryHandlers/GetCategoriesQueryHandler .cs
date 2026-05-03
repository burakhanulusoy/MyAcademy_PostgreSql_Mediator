using MediatR;
using MyAcademyMediator.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediator.MediatorPattern.Results.CategoryResults;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
    {
        public Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {





        }
    }
}
