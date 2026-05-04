using MyAcademyMediator.MediatorPattern.Results.CategoryResults;

namespace MyAcademyMediator.MediatorPattern.Results.ProductResults;

public record GetProductsQueryResult(Guid Id,
                                     string Name,
                                     string ImageUrl,
                                     string Description,
                                     decimal Price,
                                     int Stock,
                                     GetCategoriesQueryResult Category);
