using System.Windows;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;

namespace FluentWPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      this.Content = new MyWindow().Create();

      this.InitializeComponent();
      this.AsFluent()
        .Size(600, 800);
    }
  }
}