using System.Windows.Controls;

namespace FluentWPFAPI.StackPanelApi
{
  public static class StackPanelExtenstions
  {
    public static IFluentItem<StackPanel> Stack(this IFluentItem<StackPanel> fluentItem, IFluentItem item)
    {
      fluentItem.Element.Children.Add(item.Element);

      return fluentItem;
    }
  }
}
