using System.Windows.Controls;

namespace FluentWPFAPI.ProgressApi
{
  public static class ProgressExtensions
  {
    public static IFluentItem<ProgressBar> Indeterminate(this IFluentItem<ProgressBar> item)
    {
      item.Element.IsIndeterminate = true;

      return item;
    }

    public static IFluentItem<ProgressBar> Vertical(this IFluentItem<ProgressBar> item)
    {
      item.Element.Orientation = Orientation.Vertical;

      return item;
    }

    public static IFluentItem<ProgressBar> Horizontal(this IFluentItem<ProgressBar> item)
    {
      item.Element.Orientation = Orientation.Horizontal;

      return item;
    }

    public static IFluentItem<ProgressBar> Minium(this IFluentItem<ProgressBar> item, double value)
    {
      item.Element.Minimum = value;

      return item;
    }

    public static IFluentItem<ProgressBar> Maximum(this IFluentItem<ProgressBar> item, double value)
    {
      item.Element.Maximum = value;

      return item;
    }

    public static IFluentItem<ProgressBar> Value(this IFluentItem<ProgressBar> item, double value)
    {
      item.Element.Value = value;

      return item;
    }
  }
}
