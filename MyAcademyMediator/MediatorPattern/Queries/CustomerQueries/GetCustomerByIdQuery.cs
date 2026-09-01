using MediatR;
using MyAcademyMediator.MediatorPattern.Results.CustomerResults;

namespace MyAcademyMediator.MediatorPattern.Queries.CustomerQueries;

public class GetCustomerByIdQuery(Guid Id):IRequest<GetCustomerByIdQueryResult>
{

           public Guid Id { get; set; } = Id;

}
