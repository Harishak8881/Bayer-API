using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
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
        public async Task<IActionResult> GetUserByUserName([FromQuery] string username)
        {
          var result= await _userService.GetUser(username);
           return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] UserDTO userDTO)
        {
            var result = await _userService.InsertUser(userDTO);
            return Ok(result);
        }
    }
}
