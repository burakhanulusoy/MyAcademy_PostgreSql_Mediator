namespace MyAcademyMediator.MediatorPattern.Results.CustomerResults;

public record GetCustomersQueryResult(Guid Id,
                                      string NameSurname,
                                      string City,
                                      string PhoneNumber,
                                      string Address);

