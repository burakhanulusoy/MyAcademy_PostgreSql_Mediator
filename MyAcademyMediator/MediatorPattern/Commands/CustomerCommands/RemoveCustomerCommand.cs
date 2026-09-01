using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;

public record RemoveCustomerCommand(Guid Id) : IRequest;
