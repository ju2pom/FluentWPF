using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;

namespace FluentWPF
{
  public partial class Theme
  {
    public override void LoadCheckBoxStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Template<CheckBox>()
          .Factory<CheckBox, Border>()
          .Bind(Control.BackgroundProperty, Control.BackgroundProperty)
          .Factory<CheckBox, ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .Bind(ContentPresenter.ContentProperty, ContentControl.ContentProperty)
          .Get();

      var style = StyleExtensions.Style<CheckBox>()
        .When(ToggleButton.IsCheckedProperty)
        .Is(true)
        .Then(Control.FontWeightProperty, FontWeights.Bold)
        .Then(Control.ForegroundProperty, new SolidColorBrush(Colors.DarkBlue))
        .EndWhen()
        .When(UIElement.IsMouseOverProperty)
        .Is(true)
        .Then(Control.BackgroundProperty, new SolidColorBrush(Colors.Bisque))
        .EndWhen()
        .Template(template)
        .Get();

      this.Add(typeof(CheckBox), style);
    }
  }
}
