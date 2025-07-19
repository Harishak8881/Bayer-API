using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Bayer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        public UserController(IUserService userService) {         
            _userService = userService;
        }

        [HttpGet("username")]
        public async Task<IActionResult> Get([FromQuery] string username)
        {
          var result= await _userService.GetUser(username);
           return Ok(result);
        }
    }
}
