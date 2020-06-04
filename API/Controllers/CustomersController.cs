using System.Net;
using System.Threading.Tasks;
using Application.Handlers.Base.Failures;
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

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomer.Request request)
        {
            return CommandResponse(await Mediator.Send(request),
                HttpStatusCode.Created,
                failure => failure switch
                {
                    ConflictFailure _ => HttpStatusCode.Conflict,
                    _ => HttpStatusCode.BadRequest
                });
        }
    }
}