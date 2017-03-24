using System.Windows.Controls;

namespace FluentWPFAPI.ProgressApi
{
  public static class ProgressExtensions
  {
    public static IFluentItem<ProgressBar> Indeterminate(this IFluentItem<ProgressBar> item)
    {
      Get(item).IsIndeterminate = true;

      return item;
    }

    public static IFluentItem<ProgressBar> Vertical(this IFluentItem<ProgressBar> item)
    {
      Get(item).Orientation = Orientation.Vertical;

      return item;
    }

    public static IFluentItem<ProgressBar> Horizontal(this IFluentItem<ProgressBar> item)
    {
      Get(item).Orientation = Orientation.Horizontal;

      return item;
    }

    public static IFluentItem<ProgressBar> Minium(this IFluentItem<ProgressBar> item, double value)
    {
      Get(item).Minimum = value;

      return item;
    }

    public static IFluentItem<ProgressBar> Maximum(this IFluentItem<ProgressBar> item, double value)
    {
      Get(item).Maximum = value;

      return item;
    }

    public static IFluentItem<ProgressBar> Value(this IFluentItem<ProgressBar> item, double value)
    {
      Get(item).Value = value;

      return item;
    }

    private static ProgressBar Get(IFluentItem<ProgressBar> item)
    {
      return ((FluentItem<ProgressBar>)item).Element;
    }
  }
}
