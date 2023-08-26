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
            var accessToken = HttpContextAccessor.HttpContext.Request.Headers.Authorization.ToString()
                .Replace("Bearer ", "");
            var spotifyClient = new SpotifyClient(accessToken);
            return spotifyClient;
        }
    }
}