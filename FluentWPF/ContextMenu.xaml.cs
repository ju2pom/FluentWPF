using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetContextMenuStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<Border>()
        .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
        .TemplateBinding(Control.BorderBrushProperty, Control.BorderBrushProperty)
        .TemplateBinding(Control.BorderThicknessProperty, Control.BorderThicknessProperty)
        .Contains(TemplateExtensions.Create<StackPanel>()
          .Set(Panel.IsItemsHostProperty, true))
        .AsControlTemplate<ContextMenu>();

      return StyleExtensions.Create()
        .Set(Control.ForegroundProperty, colors.Text.Normal)
        .Set(Control.BackgroundProperty, colors.Control.Accent1)
        .Set(Control.BorderBrushProperty, colors.Control.Accent1)
        .Set(Control.BorderThicknessProperty, new Thickness(1))
        .Template(template)
        .AsStyle<ContextMenu>();
    }
  }
}