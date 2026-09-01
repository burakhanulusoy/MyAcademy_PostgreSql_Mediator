using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;

public record UpdateCustomerCommand(Guid Id,
                                    string NameSurname,
                                    string City,
                                    string PhoneNumber,
                                    string Address) :IRequest;
