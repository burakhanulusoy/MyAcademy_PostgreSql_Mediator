using MediatR;
using MyAcademyMediator.MediatorPattern.Results.ProductResults;

namespace MyAcademyMediator.MediatorPattern.Queries.ProductQueries;

public record GetProductsQuery:IRequest<List<GetProductsQueryResult>>;
