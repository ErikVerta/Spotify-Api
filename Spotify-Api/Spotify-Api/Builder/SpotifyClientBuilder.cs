using Microsoft.AspNetCore.Authentication;
using SpotifyAPI.Web;

namespace Spotify_Api.Builder
{
    public class SpotifyClientBuilder : ISpotifyClientBuilder
    {
        private IHttpContextAccessor HttpContextAccessor { get; }

        public SpotifyClientBuilder(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<SpotifyClient> BuildClientAsync()
        {
            var accessToken = await HttpContextAccessor.HttpContext.GetTokenAsync("Spotify", "access_token");
            var spotifyClient = new SpotifyClient(accessToken);
            return spotifyClient;
        }
    }
}