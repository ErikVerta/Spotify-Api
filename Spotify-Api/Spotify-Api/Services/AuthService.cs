using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public class AuthService
    {
        public LoginRequest LoginRequest { get; set; }

        public AuthService()
        {
            var loginRequest = new LoginRequest(
                new Uri("https://localhost:5521"),
                "ClientId",
                SpotifyAPI.Web.LoginRequest.ResponseType.Code);
            var uri = loginRequest.ToUri();
        }

        public void GetLoginRequest()
        {
        }
    }
}