using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPF
{
  public partial class Theme
  {
    public Style GetWindowStyle(IThemeColors colors)
    {
      return StyleExtensions.Create()
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .AsStyle<Window>();
    }
  }
}
