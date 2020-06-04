using System.Threading.Tasks;
using Application.Handlers.Orders.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrders(CreateOrder.Request request)
        {
            return CreatedCommandResponse(await Mediator.Send(request));
        }
    }
}