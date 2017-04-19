using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentWPF.Interfaces
{
  public interface IMediaConnector
  {
    Task<IEnumerable<IArtist>> SearchArtist(string artist);
  }
}
