
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("secure")]
        public IActionResult Secure()
        {
            return Ok(new
            {
                message = "JWT Authentication is working!",
                user = User.Identity?.Name
            });
        }
    }
}
