using System.Text.Json;
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

        //[HttpGet("callback")]
        //public async Task<ActionResult<string>> Callback([FromQuery] string code, [FromQuery] string state)
        //{
        //    var response = await new OAuthClient().RequestToken(
        //        new AuthorizationCodeTokenRequest(Configuration["Spotify:SPOTIFY_CLIENT_ID"],
        //            Configuration["Spotify:SPOTIFY_CLIENT_SECRET"], code,
        //            new Uri("https://localhost:32768/Auth/callback")));
        //    return Ok(JsonSerializer.Serialize(response));
        //}

        //[HttpGet("login")]
        //public async Task<ActionResult<string>> Login()
        //{
        //    var loginRequest = new LoginRequest(
        //        new Uri("https://localhost:32768/Auth/callback"),
        //        Configuration["Spotify:SPOTIFY_CLIENT_ID"],
        //        LoginRequest.ResponseType.Code)
        //    {
        //        Scope = new[] {Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.UserTopRead},
        //        State = Guid.NewGuid().ToString()
        //    };
        //    var uri = loginRequest.ToUri();
        //    return Redirect(uri.ToString());
        //}

        //[HttpGet("refresh_token")]
        //public async Task<ActionResult<string>> RefreshToken([FromQuery] string refreshToken)
        //{
        //    if (string.IsNullOrEmpty(refreshToken))
        //        return BadRequest("refresh_token is null or empty.");

        //    var response = await new OAuthClient().RequestToken(
        //        new AuthorizationCodeRefreshRequest(Configuration["Spotify:SPOTIFY_CLIENT_ID"],
        //            Configuration["Spotify:SPOTIFY_CLIENT_SECRET"], refreshToken));

        //    return Ok(JsonSerializer.Serialize(response));
        //}
    }
}