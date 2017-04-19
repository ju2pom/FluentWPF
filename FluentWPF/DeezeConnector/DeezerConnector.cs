using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E.Deezer;
using FluentWPF.Interfaces;
using FluentWPF.Media;
using IArtist = FluentWPF.Interfaces.IArtist;

namespace FluentWPF.DeezeConnector
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

      return artists.Select(x => new DeezerArtist(x));
    }
  }
}
