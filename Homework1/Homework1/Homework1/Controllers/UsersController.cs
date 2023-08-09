using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var users = StaticDb.UserNames;
            return Ok(users);
        }

        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            var user = StaticDb.UserNames.FirstOrDefault(u => u == userName);
            if (user == null)
            {
                return NotFound($"User '{userName}' not found.");
            }
            return Ok(user);
        }
    }
}