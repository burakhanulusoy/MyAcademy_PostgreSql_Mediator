using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
