using MediatR;
using MyAcademyMediator.MediatorPattern.Results.CategoryResults;

namespace MyAcademyMediator.MediatorPattern.Queries.CategoryQueries;

public record GetCategoryByIdQuery(Guid Id) : IRequest<GetCategoryByIdQueryResult>;
