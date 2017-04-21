using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetButtonStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
        .TemplateBinding(Border.PaddingProperty, Button.PaddingProperty)
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .TemplateBinding(ContentPresenter.ContentProperty, ContentControl.ContentProperty))
        .AsControlTemplate<Button>();

      return StyleExtensions.Create()
        .Set(Control.BackgroundProperty, new SolidColorBrush(Colors.Transparent))
        .Set(Control.PaddingProperty, new Thickness(4))
        .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
          .Is(true)
          .Then(Control.BackgroundProperty, colors.Control.Over))
        .Template(template)
        .AsStyle<Button>();
    }
  }
}
