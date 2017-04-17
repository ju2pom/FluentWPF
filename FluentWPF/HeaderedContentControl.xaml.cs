using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPF
{
  public partial class Theme
  {
    private Style GetHeaderContentControlStyle(IThemeColors colors)
    {
      var template = TemplateExtensions.Create<DockPanel>()
          .Contains(TemplateExtensions.Create<Border>()
            //.Set(Border.CornerRadiusProperty, new CornerRadius(3, 3, 0, 0))
            .Set(Control.BackgroundProperty, colors.Control.Accent1)
            //.Set(Border.BorderBrushProperty, colors.Outline.Normal)
            //.Set(Border.BorderThicknessProperty, new Thickness(1,1,1,0))
            .Set(DockPanel.DockProperty, Dock.Top)
            .Contains(TemplateExtensions.Create<ContentPresenter>()
              .Set(ContentPresenter.ContentSourceProperty, "Header")
              .Set(FrameworkElement.MarginProperty, new Thickness(4))))
          .Contains(TemplateExtensions.Create<Border>()
              .Set(Control.BackgroundProperty, colors.Control.Accent2)
              .Set(Border.BorderBrushProperty, colors.Outline.Normal)
              .Set(Border.BorderThicknessProperty, new Thickness(1, 1, 1, 1))
              .Contains(TemplateExtensions.Create<ContentPresenter>()))
          .AsControlTemplate<HeaderedContentControl>();

      return StyleExtensions.Create()
        .Template(template)
        .AsStyle<HeaderedContentControl>();
    }
  }
}
