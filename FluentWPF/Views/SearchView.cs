﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FluentWPF.CustomControls;
using FluentWPF.Interfaces;
using FluentWPF.ViewModel;
using FluentWPFAPI;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.ImageApi;
using FluentWPFAPI.ThemeApi.Binding;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPF.Views
{
  public class SearchView : TabItem
  {
    private readonly IFluentItem<TabItem> fluentItem;

    public SearchView()
    {
      var bmp = new BitmapImage(new Uri(@"pack://application:,,,/Resources/no-artist.png", UriKind.Absolute));

      var dataTemplate = TemplateExtensions.Create<DockPanel>()
          .Contains(TemplateExtensions.Create<Image>()
            .Set(DockPanel.DockProperty, Dock.Left)
            .Set(Control.HeightProperty, 25d)
            .Set(Control.WidthProperty, 25d)
            .Bind(Image.SourceProperty, nameof(IArtist.PictureUri), null, bmp))
          .Contains(TemplateExtensions.Create<TextBlock>()
            .Set(Control.MarginProperty, new Thickness(8, 0, 0, 0))
            .Set(Control.VerticalAlignmentProperty, VerticalAlignment.Center)
            .Set(Control.MaxWidthProperty, 250d)
            .Set(Control.HorizontalAlignmentProperty, HorizontalAlignment.Left)
            .Set(TextBlock.TextWrappingProperty, TextWrapping.WrapWithOverflow)
            .Bind(TextBlock.TextProperty, nameof(IArtist.Name)))
        .AsDataTemplate<IArtist>();

      var navigationButtonStyle = StyleExtensions.Create()
        .BasedOn<Button>()
        .Set(Control.HorizontalAlignmentProperty, HorizontalAlignment.Left)
        .Set(FrameworkElement.MarginProperty, new Thickness(4))
        .Set(Control.FontSizeProperty, 18d)
        .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI symbol"))
        .When(TriggerExtensions
          .Property(FrameworkElement.IsEnabledProperty)
          .Is(false)
          .Then(FrameworkElement.VisibilityProperty, Visibility.Hidden))
        .AsStyle<Button>();

      this.fluentItem = this.AsFluent<TabItem>()
        .Bind(BindingExtensions
          .OneTime(FrameworkElement.DataContextProperty)
          .With(nameof(RootViewModel.Search)))
        .Set(FrameworkElement.VisibilityProperty, Visibility.Collapsed)
        .Contains(new Grid()
          .AsFluent()
          .Margin(0, 25, 0, 0)
          .Cell(GridCellExtensions.Create()
            .Contains(new Button()
              .AsFluent()
              .UseStyle(navigationButtonStyle)
              .Contains("")
              .SubDataContext(nameof(SearchViewModel.NavigationViewModel))
              .Bind(BindingExtensions
                .OneTime(ButtonBase.CommandProperty)
                .With(nameof(SearchNavigationViewModel.GoBackCommand)))))
          .Cell(GridCellExtensions.Create()
            .Column(1).AutoWidth()
            .Contains(new TextBlock()
              .AsFluent()
              .Set(FrameworkElement.MarginProperty, new Thickness(4))
              .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
              .Set(TextBlock.TextProperty, "Search")))
          .Cell(GridCellExtensions.Create()
            .Column(2).Width("*")
            .Contains(new TextBox()
              .AsFluent()
              .Bind(BindingExtensions
                .TwoWay(TextBox.TextProperty)
                .With(nameof(SearchViewModel.Search)))
              .Set(FrameworkElement.MarginProperty, new Thickness(4))
              .Set(TextBox.VerticalContentAlignmentProperty, VerticalAlignment.Center)
              .On(TextBoxBase.KeyUpEvent, OnTextChanged)))
          .Cell(GridCellExtensions.Create()
            .Column(3).AutoWidth()
            .Contains(new DropDownButton()
              .AsFluent()
              .Contains("⋮")
              .Set(Control.FontFamilyProperty, new FontFamily("Segoe UI symbol"))
              .Set(Control.FontSizeProperty, 18d)
              .Set(Control.ContextMenuProperty, SearchContextMenuBuilder.Create())))
          .Cell(GridCellExtensions.Create()
            .Row(1).Span(1, 4).Height("*")
            .Contains(new ListBox()
              .AsFluent()
              .Set(ListBox.MarginProperty, new Thickness(4))
              .Set(ListBox.ItemTemplateProperty, dataTemplate)
              .Bind(BindingExtensions
                .OneWay(ListBox.ItemsSourceProperty)
                .With(nameof(SearchViewModel.Artists)))
              ))
        );
    }

    public IFluentItem<TabItem> AsFluent()
    {
      return this.fluentItem;
    }

    private void OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
    {
      KeyEventArgs eventArgs = routedEventArgs as KeyEventArgs;
      if (eventArgs != null && eventArgs.Key == Key.Enter)
      {
        TextBox textBox = sender as TextBox;
        SearchViewModel vm = textBox.DataContext as SearchViewModel;

        vm.SearchArtistCommand.Execute(textBox.Text);
      }
    }
  }
}