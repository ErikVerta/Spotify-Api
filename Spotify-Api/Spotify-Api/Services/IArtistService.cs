using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public interface IArtistService
    {
        public Task<IEnumerable<SimpleAlbum>> GetArtistsAlbumsAsync(string artistId);
    }
}