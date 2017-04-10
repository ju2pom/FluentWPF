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

namespace FluentWPF
{
  public class MyWindow
  {
    private readonly ContentControl _content;

    public MyWindow()
    {
      this._content = new ContentControl { DataContext = new MyWindowDataContext() }
        .AsFluent()
        .Size(400, 150)
        .Contains(new Grid()
          .AsFluent()
          .Set(x => x.Background, new SolidColorBrush(Colors.RosyBrown))
          .Set(FrameworkElement.ToolTipProperty, "Media player")
          .DefaultCellSize("25", "1")
          .Cell(0, 0).Height(20).Span(3, 2)
          .Contains(new Image()
            .AsFluent()
            .From(@"/Resources/Queen_Jazz.png")
            .Stretch(Stretch.Fill)
            .Margin(10))
          .Cell(1, 2)
          .Contains(new CheckBox()
            .AsFluent()
            .Center()
            .Contains("Shuffle")
            .Bind(BindingExtensions
              .Property(ToggleButton.IsCheckedProperty)
              .OneWay(nameof(MyWindowDataContext.IsShuffleEnabled))))
          .Cell(2, 2)
          .Contains(new CheckBox()
            .AsFluent()
            .Center()
            .Contains("Loop")
            .Bind(BindingExtensions
              .Property(ToggleButton.IsCheckedProperty)
              .OneWay(nameof(MyWindowDataContext.IsLoopEnabled))))
          .Cell(3, 0)
          .Contains(new Button()
            .AsFluent()
            .Contains("<<"))
          .Cell(3, 1)
          .Contains(new Button()
            .AsFluent()
            .Contains(">"))
          .Cell(3, 2)
          .Contains(new Button()
            .AsFluent()
            .Contains(">>"))
          .Cell(4, 0).Span(1, 3)
          .Contains(new ProgressBar()
            .AsFluent()
            .Minium(0)
            .Maximum(100)
            .Value(50)
            .MarginTop(10)
            .MarginBottom(10)))
        .Initialize();
    }

    public FrameworkElement Create()
    {
      return this._content;
    }
  }
}