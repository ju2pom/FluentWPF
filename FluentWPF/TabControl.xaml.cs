using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetTabControlStyle(IThemeColors colors)
    {
      /*var template = TemplateExtensions.Create<ItemsPresenter>()
        .AsControlTemplate<TabControl>();*/

      return StyleExtensions.Create()
        .Set(Control.PaddingProperty, new Thickness(0))
        .Set(Control.BorderThicknessProperty, new Thickness(0))
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .AsStyle<TabControl>();
    }
  }
}
