using MediatR;
using MyAcademyMediator.MediatorPattern.Results.CustomerResults;

namespace MyAcademyMediator.MediatorPattern.Queries.CustomerQueries;

public record GetCustomersQuery:IRequest<List<GetCustomersQueryResult>>;
