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
    public class CreateCustomerCommandHandler(IGenericRepository<Customer> _genericRepository,
                                              IUnitOfWork unitOfWork,
                                              IValidator<CreateCustomerCommand> validator) : IRequestHandler<CreateCustomerCommand>
    {
        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
            {
                throw new ApiValidationException(validationResult.Errors);
            }

            var mappedCustomer = request.Adapt<Customer>();

            await  _genericRepository.CreateAsync(mappedCustomer);

            await unitOfWork.SaveChangesAsync();



        }
    }
}
