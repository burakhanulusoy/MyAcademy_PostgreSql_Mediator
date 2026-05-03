using FluentValidation;
using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.Exceptions;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;
using MyAcademyMediator.Repositories;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler(IGenericRepository<Category> _genericRepository
                                              ,IValidator<CreateCategoryCommand> _validator) : IRequestHandler<CreateCategoryCommand>
    {
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                throw new ApiValidationException(validationResult.Errors);
            }

            var mappedCategory = request.Adapt<Category>();

            await _genericRepository.CreateAsync(mappedCategory);


        }
    }
}
