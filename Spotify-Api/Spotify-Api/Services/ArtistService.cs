using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public class ArtistService : IArtistService
    {
        public async Task<IEnumerable<SimpleAlbum>> GetArtistsAlbumsAsync(string accessToken, string artistId)
        {
            var spotifyClient = new SpotifyClient(accessToken);

            var albums = await spotifyClient.Artists.GetAlbums(artistId);
            return albums.Items;
        }
    }
}