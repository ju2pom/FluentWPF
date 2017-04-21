using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetTextBlockStyle(IThemeColors colors)
    {
      return StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .AsStyle<TextBlock>();
    }
  }
}
