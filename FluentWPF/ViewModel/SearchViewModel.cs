using System.Collections.Generic;
using System.Windows.Input;
using FluentWPF.Interfaces;
using FluentWPF.Spotify;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FluentWPF.ViewModel
{
  public class SearchViewModel : ViewModelBase
  {
    private readonly IMediaConnector connector;

    private IEnumerable<IArtist> results;

    public SearchViewModel()
    {
      this.connector = new SpotifyConnector();
      this.SearchArtistCommand = new RelayCommand<string>(this.SearchArtist);
    }


    public ICommand SearchArtistCommand { get; }

    public IEnumerable<IArtist> Artists
    {
      get { return this.results; }
    }

    private async void SearchArtist(object obj)
    {
      string artistName = (string)obj;

      this.results = await this.connector.SearchArtist(artistName);
      this.RaisePropertyChanged(nameof(this.Artists));
    }
  }
}
