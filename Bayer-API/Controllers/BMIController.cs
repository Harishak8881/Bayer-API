using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Bayer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMIController : ControllerBase
    {
        readonly IBMIService _bMIService;
        public BMIController(IBMIService bMIService)
        {
            _bMIService = bMIService;
        }

        [HttpGet("username")]
        public IActionResult GetBMIbyUsername(string username)
        {
            var result = _bMIService.GetBMIbyUserName(username);
            return Ok(result);
        }
    }
}
