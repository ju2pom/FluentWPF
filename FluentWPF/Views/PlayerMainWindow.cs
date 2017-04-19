﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPF.ViewModel;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.HeaderedContentControlApi;
using FluentWPFAPI.TabControlApi;
using FluentWPFAPI.ThemeApi.Binding;
using FluentWPFAPI.WindowApi;

namespace FluentWPF.Views
{
  public class PlayerMainWindow : Window
  {
    private MediaBrowserViewModel mediaBrowserViewModel;

    public PlayerMainWindow()
    {
      this.mediaBrowserViewModel = new MediaBrowserViewModel();

      this.AsFluent<Window>()
        .NoBorder()
        .NoResize()
        .SizeToContent(SizeToContent.WidthAndHeight)
        .Transparent()
        .Contains(new Grid()
            .AsFluent()
            .Cell(GridCellExtensions.Create()
              .AutoHeight()
              .Contains(new Expander()
                .AsFluent<HeaderedContentControl>()
                .Size(300, 300)
                .Bind(BindingExtensions
                  .TwoWay(Expander.IsExpandedProperty)
                  .With(nameof(MediaBrowserViewModel.IsMenuOpened)))
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
                        .OneTime(ButtonBase.CommandProperty)
                        .With(nameof(MediaBrowserViewModel.OpenSearchViewCommand)))))
                  .Cell(GridCellExtensions.Create()
                    .Column(1)
                    .Contains(new Button()
                      .AsFluent()
                      .Contains("\xE8D6")
                    .Bind(BindingExtensions
                      .OneTime(ButtonBase.CommandProperty)
                      .With(nameof(MediaBrowserViewModel.OpenPlayerViewCommand)))))
                  .Cell(GridCellExtensions.Create()
                    .Column(2)
                    .Contains(new Button()
                      .AsFluent()
                      .Contains("\xE74F"))))))
          .Cell(GridCellExtensions.Create()
            .Height("*")
            .Contains(new TabControl()
              .AsFluent()
              .Bind(BindingExtensions
                .TwoWay(TabControl.SelectedIndexProperty)
                .With(nameof(MediaBrowserViewModel.CurrentView)))
              .Tab(new PlayerView().AsFluent<TabItem>())
              .Tab(new SearchView().AsFluent<TabItem>())
            )))
        .Initialize(this.mediaBrowserViewModel);
    }
  }
}
