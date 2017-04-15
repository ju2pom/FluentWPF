using System.Windows;

namespace FluentWPF
{
  public partial class App : Application
  {
    private void OnStartup(object sender, StartupEventArgs e)
    {
      new MainWindow().Show();
    }
  }
}
