using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<FullArtist>> GetUsersTopArtistsAsync();
    }
}