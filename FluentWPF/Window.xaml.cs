using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPF
{
  public partial class Theme
  {
    public override void LoadWindowStyle(IThemeColors colors)
    {
      var style = StyleExtensions.Create()
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .AsStyle<Window>();

      this.Add(typeof(Window), style);
      this.Add(typeof(MainWindow), style);
    }
  }
}
