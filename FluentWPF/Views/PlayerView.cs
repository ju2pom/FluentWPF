using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.ImageApi;
using FluentWPFAPI.ProgressApi;
using FluentWPFAPI.StackPanelApi;

namespace FluentWPF.Views
{
  public class PlayerView : TabItem
  {
    public PlayerView()
    {
      this.AsFluent()
        .Set(FrameworkElement.VisibilityProperty, Visibility.Collapsed)
        .Contains(new StackPanel()
          .AsFluent()
          .Stack(new Image()
            .AsFluent()
            .Margin(0, 25, 0, 0)
            .Size(300, 200)
            .Stretch(Stretch.UniformToFill)
            .Source(@"/Resources/Queen_Jazz.png"))
          .Stack(new Grid()
            .AsFluent()
            .Set(Control.BackgroundProperty, Theme.ThemeColors.Control.Normal)
            .Set(FrameworkElement.HeightProperty, 80d)
            .Cell(GridCellExtensions.Create()
              .Width("*")
              .Height("*")
              .Contains(new Button()
                .AsFluent()
                .Contains("⏮")
                .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI symbol"))))
            .Set(Control.FontSizeProperty, 18d)
            .Cell(GridCellExtensions.Create()
              .Column(1)
              .Width("*")
              .Contains(new Button()
                .AsFluent()
                .Contains("▶")
                .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI symbol"))))
            .Set(Control.FontSizeProperty, 18d)
            .Cell(GridCellExtensions.Create()
              .Width("*")
              .Column(2)
              .Contains(new Button()
                .AsFluent()
                .Contains("⏭")
                .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI symbol"))))
            .Set(Control.FontSizeProperty, 18d)
            .Cell(GridCellExtensions.Create()
              .AutoHeight()
              .Row(1)
              .Span(1, 3)
              .Contains(new ProgressBar()
                .AsFluent()
                .Value(30)
                .Set(FrameworkElement.HeightProperty, 8d)
                .Set(Control.ForegroundProperty, Theme.ThemeColors.Control.Accent2)))));
    }
  }
}
