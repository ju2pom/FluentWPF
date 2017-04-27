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
    private string search;

    public SearchViewModel()
    {
      this.connector = new SpotifyConnector();
      this.SearchArtistCommand = new RelayCommand<string>(this.SearchArtist);
      this.NavigationViewModel = new SearchNavigationViewModel(this);
      this.GoBackCommand = this.NavigationViewModel.GoBackCommand;
    }

    public SearchNavigationViewModel NavigationViewModel { get; }

    public string Search
    {
      get => search;

      set
      {
        search = value;
        this.RaisePropertyChanged();
      }
    }

    public IEnumerable<IArtist> Artists => this.results;

    public ICommand SearchArtistCommand { get; }

    public ICommand GoBackCommand { get; }

    private void SearchArtist(object obj)
    {
      string artistName = (string) obj;

      this.Restore(artistName);
      this.NavigationViewModel.Push(artistName);
    }

    public async void Restore(string text)
    {
      this.Search = text;
      this.results = await this.connector.SearchArtist(text);
      this.RaisePropertyChanged(nameof(this.Artists));
      this.RaisePropertyChanged(nameof(GoBackCommand));
    }
  }
}
