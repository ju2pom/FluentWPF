using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;

namespace FluentWPF.ViewModel
{
  public class PlayerViewModel : ViewModelBase
  {
    private readonly ObservableCollection<SongViewModel> playList;

    private int currentSongIndex;
    private bool isPlaying;

    public PlayerViewModel()
    {
      this.currentSongIndex = 0;
      this.playList = new ObservableCollection<SongViewModel>();
      this.PlayCommand = new RelayCommand(this.Play, this.CanPlay);
      this.NextCommand = new RelayCommand(() => this.Change(1), () => this.CanChange(1));
      this.PreviousCommand = new RelayCommand(() => this.Change(-1), () => this.CanChange(-1));
      this.AddToPlaylistCommand = new RelayCommand<SongViewModel>(this.AddToPlaylist);
    }

    public ObservableCollection<SongViewModel> PlayList => this.playList;

    public SongViewModel NowPlaying => this.playList.ElementAtOrDefault(this.currentSongIndex);

    public ICommand PlayCommand { get; }

    public ICommand NextCommand { get; }

    public ICommand PreviousCommand { get; }

    public ICommand AddToPlaylistCommand { get; }

    public bool IsPlaying => this.isPlaying;

    private bool CanPlay()
    {
      return this.playList.Any();
    }

    private void Play()
    {
      this.isPlaying = true;
      this.RaisePropertyChanged(nameof(this.IsPlaying));
    }

    private bool CanChange(int step)
    {
      int newIndex = this.currentSongIndex + step;

      return newIndex >= 0 && newIndex < this.playList.Count;
    }

    private void Change(int step)
    {
      this.currentSongIndex += step;

      this.RaisePropertyChanged(nameof(this.NowPlaying));
    }

    private void AddToPlaylist(SongViewModel songViewModel)
    {
      // Check if the song is not already in the playlist
      this.playList.Add(songViewModel);
    }

  }
}
