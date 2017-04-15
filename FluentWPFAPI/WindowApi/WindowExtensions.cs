using System.Windows;

namespace FluentWPFAPI.WindowApi
{
  public static class WindowExtensions
  {
    public static IFluentItem<T> NoResize<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.ResizeMode = ResizeMode.NoResize;

      return fluentItem;
    }

    public static IFluentItem<Window> CanResize(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.ResizeMode = ResizeMode.CanResize;

      return fluentItem;
    }

    public static IFluentItem<Window> CanMinimize(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.ResizeMode = ResizeMode.CanMinimize;

      return fluentItem;
    }

    public static IFluentItem<Window> CanResizeWithGrip(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.ResizeMode = ResizeMode.CanResizeWithGrip;

      return fluentItem;
    }
  }
}
