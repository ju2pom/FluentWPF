using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FluentWPF.Interfaces;
using FluentWPF.Spotify;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace FluentWPF.ViewModel
{
  public class SearchViewModel : ViewModelBase
  {
    private readonly IMediaConnector connector;

    private IEnumerable<IArtist> results;

    public SearchViewModel()
    {
      this.connector = new SpotifyConnector();
      this.SearchArtistCommand = new GalaSoft.MvvmLight.Command.RelayCommand<string>(this.SearchArtist);
      this.GoBackCommand = new RelayCommand(this.GoBack, this.CanGoBack);
    }

    public ICommand SearchArtistCommand { get; }

    public IEnumerable<IArtist> Artists
    {
      get { return this.results; }
    }

    public ICommand GoBackCommand { get; }

    private async void SearchArtist(object obj)
    {
      string artistName = (string)obj;

      this.results = await this.connector.SearchArtist(artistName);
      this.RaisePropertyChanged(nameof(this.Artists));
      this.RaisePropertyChanged(nameof(GoBackCommand));
    }

    private bool CanGoBack()
    {
      return this.results?.Any() ?? false;
    }

    private void GoBack()
    {

    }
  }
}
