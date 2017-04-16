using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ContentControlApi
{
  public static class ContentControlExtensions
  {
    public static IFluentItem<T> Contains<T>(this IFluentItem<T> item, IFluentItem content)
      where T : ContentControl
    {
      item.AddChild(content);

      item.Element.Content = content.Element;

      return item;
    }

    public static IFluentItem<T> Contains<T>(this IFluentItem<T> item, string content)
      where T : ContentControl
    {
      TextBlock element = new TextBlock { Text = content};
      item.Element.Content = element;
      item.AddChild(new FluentItem<TextBlock>(element));

      return item;
    }

    public static IFluentItem<T> Size<T>(this IFluentItem<T> item, int width, int height)
      where T : FrameworkElement
    {
      item.Element.Width = width;
      item.Element.Height = height;

      return item;
    }
  }
}