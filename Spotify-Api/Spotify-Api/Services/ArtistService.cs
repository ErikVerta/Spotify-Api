using Spotify_Api.Builder;
using SpotifyAPI.Web;

namespace Spotify_Api.Services
{
    public class ArtistService : IArtistService
    {
        public ISpotifyClientBuilder SpotifyClientBuilder { get; set; }

        public ArtistService(ISpotifyClientBuilder spotifyClientBuilder)
        {
            SpotifyClientBuilder = spotifyClientBuilder;
        }
        public async Task<IEnumerable<SimpleAlbum>> GetArtistsAlbumsAsync(string artistId)
        {
            var spotifyClient = await SpotifyClientBuilder.BuildClientAsync();

            var albums = await spotifyClient.Artists.GetAlbums(artistId);
            return albums.Items;
        }
    }
}