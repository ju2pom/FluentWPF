using FluentWPF.Interfaces;

namespace FluentWPF.Media
{
  public class DeezerArtist : IArtist
  {
    private readonly E.Deezer.Api.IArtist artist;

    public DeezerArtist(E.Deezer.Api.IArtist artist)
    {
      this.artist = artist;
    }

    public string Name => this.artist.Name;

    public string Id => this.artist.Id.ToString();

    public string Link => this.artist.Link;
  }
}
