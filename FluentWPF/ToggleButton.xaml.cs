using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetToggleButtonStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Border.BackgroundProperty, ToggleButton.BackgroundProperty)
        .Contains(TemplateExtensions.Create<ContentPresenter>())
        .AsControlTemplate<ToggleButton>();

      return StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .Set(Control.BackgroundProperty, new SolidColorBrush(Colors.Transparent))
        .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
          .Is(true)
          .Then(Control.BackgroundProperty, colors.Control.Over))
        .Template(template)
        .AsStyle<ToggleButton>();
    }
  }
}
