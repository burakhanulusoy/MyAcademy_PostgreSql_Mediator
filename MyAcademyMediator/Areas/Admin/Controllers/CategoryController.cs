using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyMediator.MediatorPattern.Commands.CategoryCommands;
using MyAcademyMediator.MediatorPattern.Queries.CategoryQueries;
using System.Threading.Tasks;

namespace MyAcademyMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
                                                 //içine request bekliyor
            var items = await _mediator.Send(new GetCategoriesQuery()); 
            return View(items);
        }

        public async Task<IActionResult> UpdateCategory(Guid id)
        {

            var item= await _mediator.Send(new GetCategoryByIdQuery(id));

            var updateItem = item.Adapt<UpdateCategoryCommand>();

            return View(updateItem);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));


        }



        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _mediator.Send(createCategoryCommand);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return RedirectToAction(nameof(Index));

        }


    }
}
