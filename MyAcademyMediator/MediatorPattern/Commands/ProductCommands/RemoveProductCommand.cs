using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.ProductCommands;

public record RemoveProductCommand(Guid Id) :IRequest;
