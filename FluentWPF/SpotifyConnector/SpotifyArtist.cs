using FluentWPF.Interfaces;
using SpotifyAPI.Web.Models;

namespace FluentWPF.SpotifyConnector
{
  public class SpotifyArtist : IArtist
  {
    private readonly FullArtist artist;

    public SpotifyArtist(FullArtist artist)
    {
      this.artist = artist;
    }

    public string Name => this.artist.Name;

    public string Id => this.artist.Id;

    public string Link => this.artist.Uri;
  }
}