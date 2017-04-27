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
    private Style GetListBoxItemStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch)
        .Contains(TemplateExtensions.Create<ContentPresenter>())
        .TemplateBinding(Border.BackgroundProperty, ListBoxItem.BackgroundProperty)
        .AsControlTemplate<ListBoxItem>();

      return StyleExtensions.Create()
        .Template(template)
        .Set(Control.PaddingProperty, new Thickness(0, 4, 0, 0))
        .Set(Control.BackgroundProperty, colors.Control.Normal)
        .Set(Control.BorderBrushProperty, colors.Control.Accent1)
        .Set(Control.BorderThicknessProperty, new Thickness(0, 1, 0, 0))
        .When(TriggerExtensions
          .Property(ListBoxItem.IsMouseOverProperty)
          .Is(true)
          .Then(ListBoxItem.BackgroundProperty, colors.Control.Over))
        .When(TriggerExtensions
          .Property(ListBoxItem.IsSelectedProperty)
          .Is(true)
          .Then(ListBoxItem.BackgroundProperty, colors.Control.Selected))
        .AsStyle<ListBoxItem>();
    }
  }
}
