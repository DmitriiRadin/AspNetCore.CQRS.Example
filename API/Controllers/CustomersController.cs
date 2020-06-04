using System.Net;
using System.Threading.Tasks;
using Application.Handlers.Base.Failures;
using Application.Handlers.Customers.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : BaseApiController
    {
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