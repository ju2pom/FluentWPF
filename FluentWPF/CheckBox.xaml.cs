using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetCheckBoxStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
        .TemplateBinding(Control.BorderBrushProperty, Control.BorderThicknessProperty)
        .TemplateBinding(Control.BorderThicknessProperty, Control.BorderThicknessProperty)
        .Contains<StackPanel>()
        .Set(StackPanel.OrientationProperty, Orientation.Horizontal)
        .Contains(TemplateExtensions.Create<Ellipse>()
          .Size(8, 8)
          .TemplateBinding(Shape.FillProperty, Control.ForegroundProperty))
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Center())
        .AsControlTemplate<CheckBox>();

      return StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .When(TriggerExtensions.Property(ToggleButton.IsCheckedProperty)
          .Is(true)
          .Then(Control.FontWeightProperty, FontWeights.Bold)
          .Then(Control.ForegroundProperty, colors.Control.Selected))
        .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
          .Is(true)
          .Then(Control.BackgroundProperty, colors.Control.Over))
        .When(TriggerExtensions.Property(FrameworkElement.TagProperty)
          .Is("test")
          .Then(ContentControl.ContentProperty, null))
        .Template(template)
        .AsStyle<CheckBox>();
    }
  }
}
