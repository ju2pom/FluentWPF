using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FluentWPF.Interfaces;
using FluentWPF.ViewModel;
using FluentWPFAPI;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.ImageApi;
using FluentWPFAPI.StackPanelApi;
using FluentWPFAPI.ThemeApi.Binding;
using FluentWPFAPI.ThemeApi.Template;

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
            .Set(Control.MarginProperty, new Thickness(8,0,0,0))
            .Set(Control.VerticalAlignmentProperty, VerticalAlignment.Center)
            .Set(Control.MaxWidthProperty, 250d)
            .Bind(TextBlock.TextProperty, nameof(IArtist.Name)))
        .AsDataTemplate<IArtist>();

      this.fluentItem = this.AsFluent<TabItem>()
        .Set(FrameworkElement.VisibilityProperty, Visibility.Collapsed)
        .Contains(new Grid()
          .AsFluent()
          .Margin(0, 40, 0, 0)
          .Cell(GridCellExtensions.Create()
            .Span(1,2).AutoWidth()
            .Contains(new StackPanel()
              .AsFluent()
              .Set(StackPanel.OrientationProperty, Orientation.Horizontal)
              .Stack(new Button()
                .AsFluent()
                .Set(Control.MarginProperty, new Thickness(4))
                .Set(Control.WidthProperty, 90d)
                .Contains(new Image()
                  .AsFluent()
                  .Source(@"/Resources/spotify.png")))
              .Stack(new Button()
                .AsFluent()
                .Set(Control.MarginProperty, new Thickness(4))
                .Set(Control.WidthProperty, 90d)
                .Contains(new Image()
                  .AsFluent()
                  .Source(@"/Resources/deezer.png"))
              )))
          .Cell(GridCellExtensions.Create()
            .Row(1).AutoWidth()
            .Contains(new TextBlock()
              .AsFluent()
              .Set(FrameworkElement.MarginProperty, new Thickness(4))
              .Set(TextBlock.TextProperty, "Search")))
          .Cell(GridCellExtensions.Create()
            .Row(1).Column(1).Width("*")
            .Contains(new TextBox()
              .AsFluent()
              .Set(FrameworkElement.MarginProperty, new Thickness(4))
              .On(TextBoxBase.KeyUpEvent, OnTextChanged)))
          .Cell(GridCellExtensions.Create()
            .Row(2).Span(1, 2).Height("*")
            .Contains(new ListBox()
              .AsFluent()
              .Set(ListBox.MarginProperty, new Thickness(4))
              .Set(ListBox.ItemTemplateProperty, dataTemplate)
              .Bind(BindingExtensions
                .OneWay(ListBox.ItemsSourceProperty)
                .With(nameof(MediaBrowserViewModel.Artists)))
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
        MediaBrowserViewModel vm = textBox.DataContext as MediaBrowserViewModel;

        vm.SearchArtistCommand.Execute(textBox.Text);
      }
    }
  }
}