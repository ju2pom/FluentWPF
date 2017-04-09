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
    public override void LoadButtonStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .Set(Border.CornerRadiusProperty, new CornerRadius(4))
        .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .TemplateBinding(ContentPresenter.ContentProperty, ContentControl.ContentProperty))
        .AsControlTemplate<Button>();

      var style = StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .Set(FrameworkElement.WidthProperty, 25d)
        .Set(FrameworkElement.HeightProperty, 25d)
        .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
          .Is(true)
          .Then(Control.BackgroundProperty, colors.Control.Over))
        .Template(template)
        .AsStyle<Button>();

      this.Add(typeof(Button), style);
    }
  }
}
