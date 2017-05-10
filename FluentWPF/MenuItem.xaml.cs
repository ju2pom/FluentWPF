using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetMenuItemStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, MenuItem.BackgroundProperty)
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Set(Control.MarginProperty, new Thickness(8))
          .Set(ContentPresenter.ContentSourceProperty, "Header"))
        .AsControlTemplate<MenuItem>();

      return StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .When(TriggerExtensions
          .Property(Control.IsMouseOverProperty)
          .Is(true)
          .Then(Control.BackgroundProperty, colors.Control.Over))
        .Template(template)
        .AsStyle<MenuItem>();
    }
  }
}
