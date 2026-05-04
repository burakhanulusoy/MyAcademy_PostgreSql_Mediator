using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;
using MyAcademyMediator.Repositories;
using MyAcademyMediator.UOW;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(IGenericRepository<Category> _genericRepository
                                            ,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCategoryCommand>
    {
        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.DeleteAsync(request.Id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
