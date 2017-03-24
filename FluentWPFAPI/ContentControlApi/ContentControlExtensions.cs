using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ContentControlApi
{
  public static class ContentControlExtensions
  {
    public static IFluentItem<T> AsFluent<T>(this T element)
      where T : FrameworkElement
    {
      return new FluentItem<T>(element);
    }

    public static IFluentItem<T> Contains<T>(this IFluentItem<T> item, IFluentItem content)
      where T : ContentControl
    {
      FluentItem<T> fluentItem = (FluentItem<T>) item;
      IInternalObjectItem contentFluentItem = (IInternalObjectItem) content;
      fluentItem.AddChild(content);

      fluentItem.Element.Content = contentFluentItem.Element;

      return item;
    }

    public static IFluentItem<T> Contains<T>(this IFluentItem<T> item, string content)
      where T : ContentControl
    {
      FluentItem<T> fluentItem = (FluentItem<T>) item;
      TextBlock element = new TextBlock { Text = content};
      fluentItem.Element.Content = element;

      return item;
    }

    public static IFluentItem<T> Size<T>(this IFluentItem<T> item, int width, int height)
      where T : FrameworkElement
    {
      FluentItem<T> fluentItem = (FluentItem<T>) item;

      fluentItem.Element.Width = width;
      fluentItem.Element.Height = height;

      return item;
    }
  }
}