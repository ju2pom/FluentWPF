using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPF
{
  public partial class Theme
  {
    public static Style HambergerMenu { get; private set; }

    private Style GetExpanderStyle(IThemeColors colors)
    {
      if (HambergerMenu == null)
      {
        var hambergerTemplate = TemplateExtensions.Create<StackPanel>()
          .Contains(TemplateExtensions.Create<DockPanel>()
            .Set(Control.BackgroundProperty, colors.Control.Normal)
            .Contains(TemplateExtensions.Create<ToggleButton>()
              .Set(ContentControl.ContentProperty, "☰")
              .Set(FrameworkElement.MarginProperty, new Thickness(4))
              .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI Symbol"))
              .Set(DockPanel.DockProperty, Dock.Left)
              .Set(Control.FontSizeProperty, 18d)
              .TemplateBinding(ToggleButton.IsCheckedProperty, Expander.IsExpandedProperty))
            .Contains(TemplateExtensions.Create<ContentPresenter>()
              .Set(FrameworkElement.MarginProperty, new Thickness(4))
              .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
              .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
              .Set(ContentPresenter.ContentSourceProperty, "Header")))
          .Contains(TemplateExtensions.Create<ContentPresenter>()
            .Set(ContentPresenter.ContentSourceProperty, "Content")
            .TemplateBinding(UIElement.VisibilityProperty, Expander.IsExpandedProperty, new BooleanToVisibilityConverter()))
          .AsControlTemplate<Expander>();

        HambergerMenu = StyleExtensions.Create()
          .Template(hambergerTemplate)
          .AsStyle<Expander>();
      }
      return null;
    }
  }
}
