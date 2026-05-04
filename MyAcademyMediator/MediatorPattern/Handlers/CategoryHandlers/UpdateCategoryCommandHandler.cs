using FluentValidation;
using Mapster;
using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.Exceptions;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;
using MyAcademyMediator.Repositories;
using MyAcademyMediator.UOW;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IGenericRepository<Category> _genericRepository
                                              ,IValidator<UpdateCategoryCommand> _validator,
                                               IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCategoryCommand>
    {
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request,cancellationToken);
            
            if(!validationResult.IsValid)
            {
                throw new ApiValidationException(validationResult.Errors);
            }

            var mapped = request.Adapt<Category>();

            await _genericRepository.UpdateAsync(mapped);
           
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
