using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FluentWPF
{
  public class MyWindowDataContext : INotifyPropertyChanged
  {
    public MyWindowDataContext()
    {
      LoopCommand = new RelayCommand(OnLoop);
      ShuffleCommand = new RelayCommand(OnShuffle);
      this.MenuItems = new List<string> {"File", "Edit", "Help"};
      this.Progress = 30.5;
      this.SongTitle = "Queen - No more of that Jazz";
    }

    public double Progress { get; }

    public string SongTitle { get; }

    public IEnumerable<string> MenuItems { get; }

    public bool IsShuffleEnabled { get; private set; }

    public bool IsLoopEnabled { get; private set; }

    public ICommand LoopCommand { get; private set; }

    public ICommand ShuffleCommand { get; private set; }

    private void OnShuffle(object obj)
    {
      IsShuffleEnabled = !IsShuffleEnabled;
      this.OnPropertyChanged(nameof(IsShuffleEnabled));
    }

    private void OnLoop(object obj)
    {
      IsLoopEnabled = !IsLoopEnabled;
      this.OnPropertyChanged(nameof(IsLoopEnabled));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}