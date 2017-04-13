using System;
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
      this._content = new DockPanel()
        .AsFluent()
        .Size(400, 150)
        .DockTop(new Menu()
          .AsFluent()
          .Bind(BindingExtensions
            .Property(ItemsControl.ItemsSourceProperty)
            .OneTime(nameof(MyWindowDataContext.MenuItems))))
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
                .Property(ButtonBase.CommandProperty)
                .OneWay(nameof(MyWindowDataContext.ShuffleCommand)))))
          .Cell(GridCellExtensions.Create()
            .Row(2).Column(2)
            .Contains(new CheckBox()
              .AsFluent()
              .Center()
              .Contains("Loop")
              .Bind(BindingExtensions
                .Property(ButtonBase.CommandProperty)
                .OneWay(nameof(MyWindowDataContext.LoopCommand)))))
          .Cell(GridCellExtensions.Create()
            .Row(3).Column(0).Span(1, 3)
            .AutoHeight()
            .Contains(new TextBlock()
              .AsFluent()
              .Center()
              .Bind(BindingExtensions
                .Property(TextBlock.TextProperty)
                .OneWay(nameof(MyWindowDataContext.SongTitle)))))
          .Cell(GridCellExtensions.Create()
            .Row(4).Column(0)
            .AutoHeight()
            .Contains(new Button()
              .AsFluent()
              .Contains("<<")))
          .Cell(GridCellExtensions.Create()
            .Row(4).Column(1)
            .Contains(new Button()
              .AsFluent()
              .Contains(">")))
          .Cell(GridCellExtensions.Create()
            .Row(4).Column(2)
            .Contains(new Button()
              .AsFluent()
              .Contains(">>")
              .On(Button.ClickEvent, OnNextSong)))
          .Cell(GridCellExtensions.Create()
            .Row(5).Column(0).Span(1, 3)
            .Contains(new ProgressBar()
              .AsFluent()
              .Bind(BindingExtensions
                .Property(RangeBase.ValueProperty)
                .OneWay(nameof(MyWindowDataContext.Progress))
                .Convert(x => Math.Round((double)x)))
              .Minium(0)
              .Maximum(100)
              .MarginTop(10)
              .MarginBottom(10))))
        .Initialize(new MyWindowDataContext());
    }

    private void OnNextSong(object sender, RoutedEventArgs routedEventArgs)
    {
      Button btn = sender as Button;
      btn.Foreground = new SolidColorBrush(Colors.Blue);
    }

    public FrameworkElement Create()
    {
      return this._content;
    }
  }
}