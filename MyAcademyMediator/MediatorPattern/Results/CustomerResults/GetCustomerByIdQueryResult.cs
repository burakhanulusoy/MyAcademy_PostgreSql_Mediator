namespace MyAcademyMediator.MediatorPattern.Results.CustomerResults;

public record GetCustomerByIdQueryResult(Guid Id,
                                          string NameSurname,
                                          string City,
                                          string PhoneNumber,
                                          string Address);
