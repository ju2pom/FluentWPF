using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentWPF.Interfaces;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using IArtist = FluentWPF.Interfaces.IArtist;

namespace FluentWPF.Spotify
{
  public class SpotifyConnector : IMediaConnector
  {
    private readonly SpotifyWebAPI spotify;

    public SpotifyConnector()
    {
      this.spotify = new SpotifyWebAPI {UseAuth = false};
    }

    public async Task<IEnumerable<IArtist>> SearchArtist(string artist)
    {
      var searchItemsAsync = await this.spotify.SearchItemsAsync(artist, SearchType.Artist);

      return searchItemsAsync.Artists.Items.Select(x => new SpotifyArtist(x));
    }
  }
}
