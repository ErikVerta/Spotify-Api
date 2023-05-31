using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Spotify_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet("/callback")]
        public async Task<ActionResult<string>> GetToken([FromQuery] string code, [FromQuery] string state)
        {
            if (state is null) return BadRequest();
            var codetest = code;
            return Ok();
        }
    }
}