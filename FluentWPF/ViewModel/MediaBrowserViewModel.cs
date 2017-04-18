using System.Collections.Generic;
using System.Windows.Input;
using FluentWPF.Interfaces;
using GalaSoft.MvvmLight;

namespace FluentWPF.ViewModel
{
  public class MediaBrowserViewModel : ViewModelBase
  {
    private readonly IMediaConnector connector;

    public MediaBrowserViewModel(IMediaConnector connector)
    {
      this.connector = connector;
      this.SearchArtistCommand = new RelayCommand(this.SearchArtist);
    }

    public ICommand SearchArtistCommand { get; }

    public IEnumerable<object> Result { get; private set; }

    private async void SearchArtist(object obj)
    {
      string artistName = (string)obj;

      this.Result = await this.connector.SearchArtist(artistName);
    }
  }
}
