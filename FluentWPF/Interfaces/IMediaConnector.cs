using System.Collections.Generic;
using System.Threading.Tasks;
using E.Deezer.Api;

namespace FluentWPF.Interfaces
{
  public interface IMediaConnector
  {
    Task<IEnumerable<IArtist>> SearchArtist(string artist);
  }
}
