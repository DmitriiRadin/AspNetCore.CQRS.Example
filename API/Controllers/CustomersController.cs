using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        public CustomersController()
        {
            
        }

        [HttpPost]
        public IActionResult RegisterCustomer()
        {
            return Ok();
        }
    }
}