using System.Windows;

namespace FluentWPFAPI.WindowApi
{
  public static class WindowExtensions
  {
    public static IFluentItem<Window> SizeToContent(this IFluentItem<Window> fluentItem, SizeToContent mode)
    {
      fluentItem.Element.SizeToContent = mode;

      return fluentItem;
    }

    public static IFluentItem<Window> NoBorder(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.WindowStyle = WindowStyle.None;

      return fluentItem;
    }

    public static IFluentItem<Window> SingleBorder(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.WindowStyle = WindowStyle.SingleBorderWindow;

      return fluentItem;
    }

    public static IFluentItem<Window> Border3D(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.WindowStyle = WindowStyle.ThreeDBorderWindow;

      return fluentItem;
    }

    public static IFluentItem<Window> ToolBorder(this IFluentItem<Window> fluentItem)
    {
      fluentItem.Element.WindowStyle = WindowStyle.ToolWindow;

      return fluentItem;
    }

    public static IFluentItem<Window> NoResize(this IFluentItem<Window> fluentItem)
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
