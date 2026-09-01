using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyMediator.MediatorPattern.Commands.CustomerCommands;
using MyAcademyMediator.MediatorPattern.Queries.CustomerQueries;

namespace MyAcademyMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var items = await _mediator.Send(new GetCustomersQuery());
            return View(items);
        }

        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _mediator.Send(new RemoveCustomerCommand(id));
            return RedirectToAction("Index");
        }

        public IActionResult CreateCustomer(Guid id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand createCustomerCommand)
        {
            await _mediator.Send(createCustomerCommand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCustomer(Guid id)
        {
            var item= await _mediator.Send(new GetCustomerByIdQuery(id));
            return View(item);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return RedirectToAction("Index");
        }


    }
}
