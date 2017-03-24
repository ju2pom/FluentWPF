using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;

namespace FluentWPF
{
  public partial class Theme
  {
    public override void LoadButtonStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Template<Button>()
          .Factory<Button, Border>()
          .Set(Border.CornerRadiusProperty, new CornerRadius(4))
          .Bind(Control.BackgroundProperty, Control.BackgroundProperty)
          .Factory<Button, ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .Bind(ContentPresenter.ContentProperty, ContentControl.ContentProperty)
          .Get();

      var style = StyleExtensions.Style<Button>()
        .Set(FrameworkElement.WidthProperty, 25d)
        .Set(FrameworkElement.HeightProperty, 25d)
        .When(UIElement.IsMouseOverProperty)
        .Is(true)
        .Then(Control.BackgroundProperty, new SolidColorBrush(Colors.Bisque))
        .EndWhen()
        .Template(template)
        .Get();

      this.Add(typeof(Button), style);
    }
  }
}
