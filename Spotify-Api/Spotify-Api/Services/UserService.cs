using Spotify_Api.Builder;
using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public class UserService : IUserService
    {
        private ISpotifyClientBuilder SpotifyClientBuilder { get; }

        public UserService(ISpotifyClientBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<IEnumerable<FullArtist>> GetUsersTopArtistsAsync()
        {
            var spotifyClient = await SpotifyClientBuilder.BuildClientAsync();

            var artists = await spotifyClient.Personalization.GetTopArtists();
            return artists.Items;
        }
    }
}