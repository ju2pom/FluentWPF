using System;
using System.Linq;
using E.Deezer;
using FluentWPF.Interfaces;

namespace FluentWPF.Deezer
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

    public string PictureUri => this.GetPicture();

    private string GetPicture()
    {
      PictureSize? size = Enum
        .GetValues(typeof(PictureSize))
        .OfType<PictureSize>()
        .FirstOrDefault(x => this.artist.HasPicture(x));

      return size.HasValue ? this.artist.GetPicture(size.Value) : string.Empty;
    }
  }
}
