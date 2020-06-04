using System.Threading.Tasks;
using Application.Handlers.Customers.Commands;
using Application.Handlers.Customers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return CommandResponse(await Mediator.Send(new GetCustomers.Request()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] GetCustomerById.Request request)
        {
            return CommandResponse(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomer.Request request)
        {
            return CreatedCommandResponse(await Mediator.Send(request));
        }
    }
}