using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Queries.CustomerQueries;
using MyAcademyMediator.MediatorPattern.Results.CustomerResults;
using MyAcademyMediator.Repositories;

namespace MyAcademyMediator.MediatorPattern.Handlers.CustomerHandlers
{
    public class GetCustomersQueryHandler(IGenericRepository<Customer> _genericRepository) : IRequestHandler<GetCustomersQuery, List<GetCustomersQueryResult>>
    {
        public async Task<List<GetCustomersQueryResult>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            
            var customers=await _genericRepository.GetAllAsync();

            return customers.Adapt<List<GetCustomersQueryResult>>();



        }
    }
}
