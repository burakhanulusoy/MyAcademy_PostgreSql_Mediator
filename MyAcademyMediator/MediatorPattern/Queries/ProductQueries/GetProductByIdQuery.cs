using MediatR;
using MyAcademyMediator.MediatorPattern.Results.ProductResults;

namespace MyAcademyMediator.MediatorPattern.Queries.ProductQueries;

public record GetProductByIdQuery(Guid Id):IRequest<GetProductByIdQueryResult>;
