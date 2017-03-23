using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

using FluentWPFAPI.BindingApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.ImageApi;
using FluentWPFAPI.ProgressApi;
using FluentWPFAPI.ThemeApi;

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
          .DefaultCellSize("25", "1")
          .Cell(0, 0).Height(20).Span(2, 2)
          .Contains(ImageExtensions.Image()
            .From(@"/Resources/Queen_Jazz.png")
            .Stretch(Stretch.Uniform)
            .Margin(10)
            )
          .Cell(1, 2)
          .Contains(new CheckBox()
            .AsFluent()
            .Center()
            .Contains("Shuffle")
            .Style(Theme.Instance.CheckBox)
            //.Style(Theme.NiceCheckBox)
            .Bind(ToggleButton.IsCheckedProperty, nameof(MyWindowDataContext.IsShuffleEnabled), BindingMode.OneWay)
            )
          .Cell(2, 2)
          .Contains(new CheckBox()
            .AsFluent()
            .Center()
            .Style(Theme.NiceCheckBox)
            .Contains("Loop")
            .Bind(ToggleButton.IsCheckedProperty, nameof(MyWindowDataContext.IsLoopEnabled), BindingMode.OneWay))
          .Cell(3, 0)
          .Contains(new Button()
            .AsFluent()
            .Contains("<<")
            )
          .Cell(3, 1)
          .Contains(new Button()
            .AsFluent()
            .Contains(">")
            )
          .Cell(3, 2)
          .Contains(new Button()
            .AsFluent()
            .Contains(">>")
            )
          .Cell(4, 0).Span(1, 3)
          .Contains(ProgressExtensions.ProgressBar()
            .Minium(0)
            .Maximum(100)
            .Value(50)
            .MarginTop(10)
            .MarginBottom(10)
            )
          )
        .Initialize();
    }

    public FrameworkElement Create()
    {
      return this._content;
    }
  }
}