using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.ImageApi;
using FluentWPFAPI.ProgressApi;
using FluentWPFAPI.ThemeApi.Binding;
using FluentWPFAPI.DockPanelApi;

namespace FluentWPF
{
  public class MyWindow
  {
    private readonly FrameworkElement _content;

    public MyWindow()
    {
      this._content = new DockPanel {DataContext = new MyWindowDataContext()}
        .AsFluent()
        .Size(400, 150)
        .DockTop(new Menu()
          .AsFluent())
        .Dock(new Grid()
          .AsFluent()
          .Set(x => x.Background, new SolidColorBrush(Colors.RosyBrown))
          .Set(FrameworkElement.ToolTipProperty, "Media player")
          .DefaultCellSize("*", "*")
          .Cell(GridCellExtensions.Create()
            .Row(0).Column(0).Span(3, 2)
            .Contains(new Image()
              .AsFluent()
              .From(@"/Resources/Queen_Jazz.png")
              .Stretch(Stretch.Fill)
              .Margin(10)))
          .Cell(GridCellExtensions.Create()
            .Row(1).Column(2)
            .Contains(new CheckBox()
              .AsFluent()
              .Center()
              .Contains("Shuffle")
              .Bind(BindingExtensions
                .Property(ToggleButton.IsCheckedProperty)
                .OneWay(nameof(MyWindowDataContext.IsShuffleEnabled)))))
          .Cell(GridCellExtensions.Create()
            .Row(2).Column(2)
            .Contains(new CheckBox()
              .AsFluent()
              .Center()
              .Contains("Loop")
              .Bind(BindingExtensions
                .Property(ToggleButton.IsCheckedProperty)
                .OneWay(nameof(MyWindowDataContext.IsLoopEnabled)))))
          .Cell(GridCellExtensions.Create()
            .Row(3).Column(0)
            .AutoHeight()
            .Contains(new Button()
              .AsFluent()
              .Contains("<<")))
          .Cell(GridCellExtensions.Create()
            .Row(3).Column(1)
            .Contains(new Button()
              .AsFluent()
              .Contains(">")))
          .Cell(GridCellExtensions.Create()
            .Row(3).Column(2)
            .Contains(new Button()
              .AsFluent()
              .Contains(">>")))
          .Cell(GridCellExtensions.Create()
            .Row(4).Column(0).Span(1, 3)
            .Contains(new ProgressBar()
              .AsFluent()
              .Minium(0)
              .Maximum(100)
              .Value(50)
              .MarginTop(10)
              .MarginBottom(10))))
        .Initialize();
    }

    public FrameworkElement Create()
    {
      return this._content;
    }
  }
}