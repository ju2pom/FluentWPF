using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetMenuItemStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, MenuItem.BackgroundProperty)
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Set(ContentPresenter.ContentSourceProperty, "Header"))
        .AsControlTemplate<MenuItem>();

      return StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .Template(template)
        .AsStyle<MenuItem>();
    }
  }
}
