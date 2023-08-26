using SpotifyAPI.Web;

namespace Spotify_Api.Builder
{
    public interface ISpotifyClientBuilder
    {
        public Task<SpotifyClient> BuildClientAsync();
    }
}