using System.Collections.Generic;
using System.Threading.Tasks;
using E.Deezer;
using E.Deezer.Api;
using FluentWPF.Interfaces;

namespace FluentWPF.MediaConnectors
{
  public class DeezerConnector : IMediaConnector
  {
    private readonly Deezer deezer;

    public DeezerConnector()
    {
      this.deezer = DeezerSession.CreateNew();
    }

    public async Task<IEnumerable<IArtist>> SearchArtist(string artist)
    {
      var artists = await this.deezer.Search.Artists(artist);

      return artists;
    }
  }
}
