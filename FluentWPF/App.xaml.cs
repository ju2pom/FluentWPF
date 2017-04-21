using System.Windows;
using FluentWPF.Views;

namespace FluentWPF
{
  public partial class App : Application
  {
    private void OnStartup(object sender, StartupEventArgs e)
    {
      new PlayerMainWindow().Show();
    }
  }
}
