using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;

public record CreateCustomerCommand(string NameSurname,
                             string City,
                             string PhoneNumber,
                             string Address) : IRequest;
