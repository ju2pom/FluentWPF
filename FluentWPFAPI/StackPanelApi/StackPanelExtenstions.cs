using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi;

namespace FluentWPFAPI.StackPanelApi
{
  public static class StackPanelExtenstions
  {
    public static IFluentItem<StackPanel> Stack(this IFluentItem<StackPanel> fluentItem, IFluentItem item)
    {
      StackPanel stackPanel = Get(fluentItem);

      stackPanel.Children.Add(item.Element);

      return fluentItem;
    }

    private static StackPanel Get(IFluentItem<StackPanel> item)
    {
      return ((FluentItem<StackPanel>)item).Element;
    }
  }
}
