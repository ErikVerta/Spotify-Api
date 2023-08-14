using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<FullArtist>> GetUsersTopArtistsAsync(string accessToken)
        {
            var spotifyClient = new SpotifyClient(accessToken);

            var artists = await spotifyClient.Personalization.GetTopArtists();
            return artists.Items;
        }
    }
}