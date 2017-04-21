using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetListBoxStyle(IThemeColors colors)
    {
      return StyleExtensions.Create()
        .Set(Control.PaddingProperty, new Thickness(0,4,0,0))
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .Set(Control.BorderBrushProperty, colors.Control.Accent1)
        .Set(Control.BorderThicknessProperty, new Thickness(0,1,0,0))
        .AsStyle<ListBox>();
    }
  }
}
