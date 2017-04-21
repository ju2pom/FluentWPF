using System;

namespace FluentWPF.Interfaces
{
  public interface IArtist
  {
    string Name { get; }

    string Id { get; }

    string Link { get; }

    string PictureUri { get; }
  }
}
