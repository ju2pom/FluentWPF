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
using FluentWPFAPI.WindowApi;

namespace FluentWPF
{
  public class MainWindow : Window
  {
    public MainWindow()
    {
      this.SetResourceReference(StyleProperty, typeof(Window));

      var content = new DockPanel()
        .AsFluent()
        .DockTop(new Menu()
          .AsFluent()
          .Bind(BindingExtensions
            .OneWay(ItemsControl.ItemsSourceProperty)
            .With(nameof(MyWindowDataContext.MenuItems))))
        .Dock(new Grid()
          .AsFluent()
          .DefaultCellSize("*", "*")
          .Cell(GridCellExtensions.Create()
            .Row(0)
            .Column(0)
            .Span(3, 2)
            .Contains(new Image()
              .AsFluent()
              .Source(@"/Resources/Queen_Jazz.png")
              .Stretch(Stretch.Fill)
              .Margin(10)))
          .Cell(GridCellExtensions.Create()
            .Row(1)
            .Column(2)
            .Contains(new CheckBox()
              .AsFluent()
              .Center()
              .Contains("Shuffle")
              .Set(FrameworkElement.ToolTipProperty, "Play playlist in random order")
              .Bind(BindingExtensions
                .OneWay(ButtonBase.CommandProperty)
                .With(nameof(MyWindowDataContext.ShuffleCommand)))))
          .Cell(GridCellExtensions.Create()
            .Row(2)
            .Column(2)
            .Contains(new CheckBox()
              .AsFluent()
              .Center()
              .Contains("Loop")
              .Set(FrameworkElement.ToolTipProperty, "Repeat playlist")
              .Bind(BindingExtensions
                .OneWay(ButtonBase.CommandProperty)
                .With(nameof(MyWindowDataContext.LoopCommand)))))
          .Cell(GridCellExtensions.Create()
            .Row(3)
            .Column(0)
            .Span(1, 3)
            .AutoHeight()
            .Contains(new TextBlock()
              .AsFluent()
              .Center()
              .Bind(BindingExtensions
                .OneWay(TextBlock.TextProperty)
                .With(nameof(MyWindowDataContext.SongTitle)))))
          .Cell(GridCellExtensions.Create()
            .Row(4)
            .Column(0)
            .AutoHeight()
            .Contains(new Button()
              .AsFluent()
              .Contains("<<")))
              .Set(FrameworkElement.ToolTipProperty, "Go to previous song")
          .Cell(GridCellExtensions.Create()
            .Row(4)
            .Column(1)
            .Contains(new Button()
              .AsFluent()
              .Contains(">")))
              .Set(FrameworkElement.ToolTipProperty, "Play")
          .Cell(GridCellExtensions.Create()
            .Row(4)
            .Column(2)
            .Contains(new Button()
              .AsFluent()
              .Contains(">>")
              .Set(FrameworkElement.ToolTipProperty, "Go to next song")
              .On(ButtonBase.ClickEvent, OnNextSong)))
          .Cell(GridCellExtensions.Create()
            .Row(5)
            .Column(0)
            .Span(1, 3)
            .Contains(new ProgressBar()
              .AsFluent()
              .Bind(BindingExtensions
                .OneWay(RangeBase.ValueProperty)
                .With(nameof(MyWindowDataContext.Progress))
                .Convert(x => Math.Round((double) x)))
              .Minium(0)
              .Maximum(100)
              .MarginTop(10)
              .MarginBottom(10))));

      this.AsFluent<Window>()
        .Contains(content)
        .Size(400, 250)
        .NoResize()
        .NoBorder()
        .Initialize(new MyWindowDataContext());
    }

    private void OnNextSong(object sender, RoutedEventArgs routedEventArgs)
    {
      PlayerView v = new PlayerView();
      v.Show();
    }
  }
}