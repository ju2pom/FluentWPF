using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FluentWPF.ViewModel
{
  public class RootViewModel : ViewModelBase
  {
    private int currentView;
    private bool isMenuOpened;

    public RootViewModel()
    {
      this.Player = new PlayerViewModel();
      this.Search = new SearchViewModel();
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

    public PlayerViewModel Player { get; }

    public SearchViewModel Search { get; }
  }
}
