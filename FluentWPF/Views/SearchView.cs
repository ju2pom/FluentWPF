using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using FluentWPF.Interfaces;
using FluentWPF.ViewModel;
using FluentWPFAPI;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
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
      var dataTemplate = TemplateExtensions.Create<TextBlock>()
        .Bind(TextBlock.TextProperty, nameof(IArtist.Name))
        .AsDataTemplate<IArtist>();

      this.fluentItem = this.AsFluent<TabItem>()
        .Set(FrameworkElement.VisibilityProperty, Visibility.Collapsed)
        .Contains(new StackPanel()
          .AsFluent()
          .Margin(0, 40, 0, 0)
          .Stack(new TextBlock()
            .AsFluent()
            .Set(TextBlock.TextProperty, "Search"))
          .Stack(new TextBox()
            .AsFluent()
            .On(TextBoxBase.KeyUpEvent, OnTextChanged))
          .Stack(new ListBox()
            .AsFluent()
            .Bind(BindingExtensions
              .OneWay(ListBox.ItemsSourceProperty)
              .With(nameof(MediaBrowserViewModel.Artists)))
            .Set(ListBox.ItemTemplateProperty, dataTemplate)
              )
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