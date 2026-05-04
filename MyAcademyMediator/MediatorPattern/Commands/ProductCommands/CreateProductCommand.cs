using MediatR;

namespace MyAcademyMediator.MediatorPattern.Commands.ProductCommands;

public record CreateProductCommand(
                                     string? Name,
                                     string? ImageUrl,
                                     string? Description,
                                     decimal? Price,
                                     int? Stock,
                                     Guid CategoryId) : IRequest;
