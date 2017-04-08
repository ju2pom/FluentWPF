using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPF
{
  public partial class Theme
  {
    public override void LoadCheckBoxStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
        .TemplateBinding(Control.BorderBrushProperty, Control.BorderThicknessProperty)
        .TemplateBinding(Control.BorderThicknessProperty, Control.BorderThicknessProperty)
        .Contains<StackPanel>()
        .Set(StackPanel.OrientationProperty, Orientation.Horizontal)
        .Contains(TemplateExtensions.Create<Ellipse>()
          .Set(FrameworkElement.WidthProperty, 8d)
          .Set(FrameworkElement.HeightProperty, 8d)
          .TemplateBinding(Shape.FillProperty, Control.ForegroundProperty))
        .Contains(TemplateExtensions.Create<ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .TemplateBinding(ContentPresenter.ContentProperty, ContentControl.ContentProperty))
        .AsControlTemplate<CheckBox>();

      var style = StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .When(ToggleButton.IsCheckedProperty)
        .Is(true)
        .Then(Control.FontWeightProperty, FontWeights.Bold)
        .Then(Control.ForegroundProperty, colors.Control.Selected)
        .EndWhen()
        .When(UIElement.IsMouseOverProperty)
        .Is(true)
        .Then(Control.BackgroundProperty, colors.Control.Over)
        .EndWhen()
/*
        .When(x => x.ActualWidth > 100)
        .Then(ContentControl.ContentProperty, null)
        .EndWhen()
*/
        .When(FrameworkElement.TagProperty)
        .Is("test")
        .Then(ContentControl.ContentProperty, null)
        .EndWhen()
        .Template(template)
        .AsStyle<CheckBox>();

      this.Add(typeof(CheckBox), style);
    }
  }
}
