using System.Windows;

namespace FluentWPFAPI.WindowApi
{
  public static class WindowExtensions
  {
    public static IFluentItem<T> NoBorder<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.WindowStyle = WindowStyle.None;

      return fluentItem;
    }

    public static IFluentItem<T> SingleBorder<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.WindowStyle = WindowStyle.SingleBorderWindow;

      return fluentItem;
    }

    public static IFluentItem<T> Border3D<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.WindowStyle = WindowStyle.ThreeDBorderWindow;

      return fluentItem;
    }

    public static IFluentItem<T> ToolBorder<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.WindowStyle = WindowStyle.ToolWindow;

      return fluentItem;
    }

    public static IFluentItem<T> NoResize<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.ResizeMode = ResizeMode.NoResize;

      return fluentItem;
    }

    public static IFluentItem<T> CanResize<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.ResizeMode = ResizeMode.CanResize;

      return fluentItem;
    }

    public static IFluentItem<T> CanMinimize<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.ResizeMode = ResizeMode.CanMinimize;

      return fluentItem;
    }

    public static IFluentItem<T> CanResizeWithGrip<T>(this IFluentItem<T> fluentItem)
      where T : Window
    {
      fluentItem.Element.ResizeMode = ResizeMode.CanResizeWithGrip;

      return fluentItem;
    }
  }
}
