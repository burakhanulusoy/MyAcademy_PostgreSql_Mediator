using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;

public record RemoveCategoryCommand(Guid Id):IRequest;

