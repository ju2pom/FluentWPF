using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using FluentWPF.ViewModel;
using FluentWPFAPI;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.StackPanelApi;

namespace FluentWPF.Views
{
  public class SearchView : TabItem
  {
    private readonly IFluentItem<TabItem> fluentItem;

    public SearchView()
    {
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