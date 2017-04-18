using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPF.MediaConnectors;
using FluentWPF.ViewModel;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.DockPanelApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.HeaderedContentControlApi;
using FluentWPFAPI.ImageApi;
using FluentWPFAPI.ProgressApi;
using FluentWPFAPI.StackPanelApi;
using FluentWPFAPI.ThemeApi.Binding;
using FluentWPFAPI.WindowApi;

namespace FluentWPF
{
  public class PlayerView : Window
  {
    private ToggleButton hambergerMenu;

    public PlayerView()
    {
      var vm = new MediaBrowserViewModel(new DeezerConnector());

      this.AsFluent<Window>()
        .NoBorder()
        .NoResize()
        .SizeToContent(SizeToContent.WidthAndHeight)
        .Transparent()
        .Contains(new DockPanel()
          .AsFluent()
          .DockTop(new Grid()
            .AsFluent()
            .Cell(GridCellExtensions.Create()
              .AutoHeight()
              .Contains(new Expander()
                .AsFluent<HeaderedContentControl>()
                .Set(Panel.ZIndexProperty, 1)
                .UseStyle(Theme.HambergerMenu)
                .Header("Titre")
                .Contains(new Grid()
                  .AsFluent()
                  .Set(Control.BackgroundProperty, Theme.ThemeColors.Control.Normal)
                  .Set(StackPanel.OrientationProperty, Orientation.Horizontal)
                  .Set(Control.FontFamilyProperty, new FontFamily("SEGOE MDL2 assets"))
                  .Set(Control.FontSizeProperty, 18d)
                  .Set(FrameworkElement.HeightProperty, 80d)
                  .DefaultCellSize("*", "*")
                  .Cell(GridCellExtensions.Create()
                    .Contains(new Button()
                      .AsFluent()
                      .Contains("\xE90B")
                      .Bind(BindingExtensions
                        .OneTime(ButtonBase.CommandParameterProperty)
                        .Source("Queen"))
                      .Bind(BindingExtensions
                        .OneTime(ButtonBase.CommandProperty)
                        .Source(vm.SearchArtistCommand))))
                  .Cell(GridCellExtensions.Create()
                    .Column(1)
                    .Contains(new Button()
                      .AsFluent()
                      .Contains("\xE735")))
                  .Cell(GridCellExtensions.Create()
                    .Column(2)
                    .Contains(new Button()
                      .AsFluent()
                      .Contains("\xE74F"))))))
            .Cell(GridCellExtensions.Create()
              .Row(0)
              .Column(0)
              .Contains(new Image()
                .AsFluent()
                .Margin(0, 25, 0, 0)
                .Size(300, 200)
                .Stretch(Stretch.UniformToFill)
                .Source(@"/Resources/Queen_Jazz.png"))))
          .Dock(new Grid()
            .AsFluent()
            .Set(Control.BackgroundProperty, Theme.ThemeColors.Control.Normal)
            .Set(FrameworkElement.HeightProperty, 80d)
            .Cell(GridCellExtensions.Create()
              .Width("*").Height("*")
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
              .Row(1).Span(1, 3)
              .Contains(new ProgressBar()
                .AsFluent()
                .Value(30)
                .Set(FrameworkElement.HeightProperty, 8d)
                .Set(Control.ForegroundProperty, Theme.ThemeColors.Control.Accent2))))
                )
        .Initialize(null);
    }
  }
}
