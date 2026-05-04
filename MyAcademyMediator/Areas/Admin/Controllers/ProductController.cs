using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyMediator.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediator.MediatorPattern.Queries.CategoryQueries;
using MyAcademyMediator.MediatorPattern.Queries.ProductQueries;




namespace MyAcademyMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IMediator _mediator) : Controller
    {

        private async Task GetCategoriesAsync()
        {

            var categories = await _mediator.Send(new GetCategoriesQuery());

            ViewBag.Categories = (from item in categories
                                  select new SelectListItem
                                  {
                                      Text = item.CategoryName,
                                      Value = item.Id.ToString()

                                  }).ToList();
        }



        public async Task<IActionResult> Index()
        {

            var response = await _mediator.Send(new GetProductsQuery());
            return View(response);
        }

        public async Task<IActionResult> DeleteProduct(Guid id)
        {

            await _mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction(nameof(Index));
        }
      
        public async Task<IActionResult> CreateProduct()
        {

            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {

            await GetCategoriesAsync();
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateProduct(Guid id)
        {

            await GetCategoriesAsync();
            var response = await _mediator.Send(new GetProductByIdQuery(id));
            var mappedUpdate = response.Adapt<UpdateProductCommand>();
            return View(mappedUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {

            await GetCategoriesAsync();
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));

        }



    }
}
