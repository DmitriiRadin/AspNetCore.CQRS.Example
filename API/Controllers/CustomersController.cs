using System.Threading.Tasks;
using Application.Handlers.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomer.Request request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}