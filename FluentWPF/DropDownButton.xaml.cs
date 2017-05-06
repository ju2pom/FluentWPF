using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FluentWPF.CustomControls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPF
{
  public partial class CustomControlsTheme
  {
    private Style GetDropDownButtonStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
        .TemplateBinding(Border.PaddingProperty, Button.PaddingProperty)
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .TemplateBinding(ContentPresenter.ContentProperty, ContentControl.ContentProperty))
          .AsControlTemplate<DropDownButton>();

      return StyleExtensions.Create()
        .Set(Control.BackgroundProperty, new SolidColorBrush(Colors.Transparent))
        .Set(Control.PaddingProperty, new Thickness(8, 4, 8, 4))
        .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
          .Is(true)
          .Then(Control.BackgroundProperty, colors.Control.Accent1))
        .Template(template)
        .AsStyle<DropDownButton>();
    }
  }
}
