using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;

public record UpdateCategoryCommand(Guid Id,string? CategoryName) :IRequest;

