using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace Spotify_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public IConfiguration Configuration { get; set; }

        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("callback")]
        public async Task<ActionResult<string>> GetToken([FromQuery] string code, [FromQuery] string state)
        {
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest(Configuration["Spotify:SPOTIFY_CLIENT_ID"],
                    Configuration["Spotify:SPOTIFY_CLIENT_SECRET"], code,
                    new Uri("https://localhost:32768/Auth/callback")));
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("login")]
        public async Task<ActionResult<string>> Login()
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:32768/Auth/callback"),
                Configuration["Spotify:SPOTIFY_CLIENT_ID"],
                LoginRequest.ResponseType.Code)
            {
                Scope = new[] {Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative},
                State = Guid.NewGuid().ToString()
            };
            var uri = loginRequest.ToUri();
            return Redirect(uri.ToString());
        }
    }
}