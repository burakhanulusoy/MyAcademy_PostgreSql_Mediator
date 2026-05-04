using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.ProductCommands;

public record UpdateProductCommand(Guid Id,
                                     string? Name,
                                     string? ImageUrl,
                                     string? Description,
                                     decimal? Price,
                                     int?     Stock,
                                     Guid CategoryId) :IRequest ;
