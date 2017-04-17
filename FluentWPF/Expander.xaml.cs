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

    private Style GetExpanderStyle(IThemeColors themeColors)
    {
      if (HambergerMenu == null)
      {
        var hambergerTemplate = TemplateExtensions.Create<StackPanel>()
          .Contains(TemplateExtensions.Create<DockPanel>()
            .Set(Control.BackgroundProperty, themeColors.Control.Normal)
            .Contains(TemplateExtensions.Create<ToggleButton>()
              .Set(ContentControl.ContentProperty, "☰")
              .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI Symbol"))
              .Set(DockPanel.DockProperty, Dock.Right)
              .Set(Control.FontSizeProperty, 18d)
              .TemplateBinding(ToggleButton.IsCheckedProperty, Expander.IsExpandedProperty))
            .Contains(TemplateExtensions.Create<ContentPresenter>()
              .Set(ContentPresenter.ContentSourceProperty, "Header")))
          .Contains(TemplateExtensions.Create<ContentPresenter>()
            .Set(ContentPresenter.ContentSourceProperty, "Content")
            .TemplateBinding(UIElement.VisibilityProperty, Expander.IsExpandedProperty, x => (bool) x ? Visibility.Visible : Visibility.Collapsed))
          .AsControlTemplate<Expander>();

        HambergerMenu = StyleExtensions.Create()
          .Template(hambergerTemplate)
          .AsStyle<Expander>();
      }
      return null;
    }
  }
}
