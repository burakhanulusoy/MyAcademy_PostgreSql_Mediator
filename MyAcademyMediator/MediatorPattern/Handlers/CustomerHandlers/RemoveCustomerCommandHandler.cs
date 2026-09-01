using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;
using MyAcademyMediator.Repositories;
using MyAcademyMediator.UOW;

namespace MyAcademyMediator.MediatorPattern.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommandHandler(IGenericRepository<Customer> _genericRepository,
                                             IUnitOfWork unitOfWork) : IRequestHandler<RemoveCustomerCommand>
    {
        public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {

            await _genericRepository.DeleteAsync(request.Id);
            await unitOfWork.SaveChangesAsync();


        }
    }
}
