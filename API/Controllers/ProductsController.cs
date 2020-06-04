using System.Threading.Tasks;
using Application.Handlers.Products.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct.Request request)
        {
            return CreatedCommandResponse(await Mediator.Send(request));
        }
    }
}