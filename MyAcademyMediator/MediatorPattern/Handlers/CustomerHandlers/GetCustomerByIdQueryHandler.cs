using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Queries.CustomerQueries;
using MyAcademyMediator.MediatorPattern.Results.CustomerResults;
using MyAcademyMediator.Repositories;

namespace MyAcademyMediator.MediatorPattern.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler(IGenericRepository<Customer> _genericRepository) : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResult>
    {
        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            
            var customer = await _genericRepository.GetByIdAsync(request.Id);

            return customer.Adapt<GetCustomerByIdQueryResult>();


        }
    }
}
