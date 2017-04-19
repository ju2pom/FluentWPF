using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using FluentWPF.ViewModel;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.StackPanelApi;

namespace FluentWPF.Views
{
  public class SearchView : TabItem
  {
    private MediaBrowserViewModel vm;

    public SearchView()
    {
      this.vm = new MediaBrowserViewModel();

      this.AsFluent()
        .Contains(new StackPanel()
          .AsFluent()
          .Stack(new TextBlock()
            .AsFluent()
            .Set(TextBlock.TextProperty, "Search"))
          .Stack(new TextBox()
            .AsFluent()
            .On(TextBoxBase.TextChangedEvent, OnTextChanged))
        )
        .Initialize(this.vm);
    }

    private void OnTextChanged(object sender, RoutedEventArgs routedEventArgs)
    {
      KeyEventArgs eventArgs = routedEventArgs as KeyEventArgs;
      if (eventArgs != null && eventArgs.Key == Key.Enter)
      {
        TextBox textBox = sender as TextBox;
        this.vm.SearchArtistCommand.Execute(textBox.Text);
      }
    }
  }
}
