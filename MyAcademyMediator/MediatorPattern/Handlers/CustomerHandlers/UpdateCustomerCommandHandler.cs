using FluentValidation;
using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.Exceptions;
using MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;
using MyAcademyMediator.Repositories;
using MyAcademyMediator.UOW;

namespace MyAcademyMediator.MediatorPattern.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler(IGenericRepository<Customer> genericRepository,
                                              IUnitOfWork unitOfWork,
                                              IValidator<UpdateCustomerCommand> validator) : IRequestHandler<UpdateCustomerCommand>
    {
        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
            {
                throw new ApiValidationException(validationResult.Errors);
            }

            var customer= request.Adapt<Customer>();

            await genericRepository.UpdateAsync(customer);

            await unitOfWork.SaveChangesAsync();





        }
    }
}
