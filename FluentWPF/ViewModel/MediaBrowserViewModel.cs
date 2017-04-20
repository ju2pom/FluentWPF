using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentWPF.DeezeConnector;
using FluentWPF.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FluentWPF.ViewModel
{
  public class MediaBrowserViewModel : ViewModelBase
  {
    private readonly IMediaConnector connector;

    private int currentView;
    private bool isMenuOpened;
    private IEnumerable<IArtist> results;

    public MediaBrowserViewModel()
    {
      this.connector = new DeezerConnector();
      this.SearchArtistCommand = new RelayCommand<string>(this.SearchArtist);
      this.OpenSearchViewCommand = new RelayCommand(() => this.CurrentView = 1);
      this.OpenPlayerViewCommand = new RelayCommand(() => this.CurrentView = 0);
    }

    public bool IsMenuOpened
    {
      get => isMenuOpened;
      set
      {
        isMenuOpened = value; 
        this.RaisePropertyChanged();
      }
    }

    public int CurrentView
    {
      get => currentView;
      set
      {
        currentView = value;
        this.IsMenuOpened = false;
        this.RaisePropertyChanged();
      }
    }

    public ICommand OpenPlayerViewCommand { get; }

    public ICommand OpenSearchViewCommand { get; }

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
