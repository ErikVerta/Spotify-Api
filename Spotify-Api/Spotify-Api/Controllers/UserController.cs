using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spotify_Api.Services;
using SpotifyAPI.Web;

namespace Spotify_Api.Controllers
{
    [ApiController]
    [Authorize("Spotify")]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IArtistService ArtistService { get; set; }
        public IUserService UserService { get; set; }

        public UserController(IArtistService artistService, IUserService userService)
        {
            ArtistService = artistService;
            UserService = userService;
        }

        [HttpGet("me/top/artists/latest/releases")]
        public async Task<ActionResult<IEnumerable<SimpleAlbum>>> GetUsersTopArtistsLatestReleases()
        {
            try
            {
                var fullArtists = await UserService.GetUsersTopArtistsAsync();

                var simpleAlbumsTasks = fullArtists.Select(async artist =>
                    await ArtistService.GetArtistsAlbumsAsync(artist.Id));

                var simpleAlbums = await Task.WhenAll(simpleAlbumsTasks);
                var latestReleases =
                    simpleAlbums.Select(simpleAlbum =>
                        simpleAlbum.MaxBy(x => x.ReleaseDate));

                return Ok(latestReleases);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}