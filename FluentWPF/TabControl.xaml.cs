using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetTabControlStyle(IThemeColors colors)
    {
      return StyleExtensions.Create()
        .Set(Control.PaddingProperty, new Thickness(0))
        .Set(Control.BorderThicknessProperty, new Thickness(0))
        .AsStyle<TabControl>();
    }
  }
}
