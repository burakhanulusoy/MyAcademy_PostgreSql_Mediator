using MediatR;
using MyAcademyMediator.Entities;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;
using MyAcademyMediator.Repositories;

namespace MyAcademyMediator.MediatorPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(IGenericRepository<Category> _genericRepository) : IRequestHandler<RemoveCategoryCommand>
    {
        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.DeleteAsync(request.Id);
        }
    }
}
