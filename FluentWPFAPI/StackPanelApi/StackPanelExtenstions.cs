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

      UIElement element = (item as IInternalObjectItem)?.Element as UIElement;
      stackPanel.Children.Add(element);

      return fluentItem;
    }

    private static StackPanel Get(IFluentItem<StackPanel> item)
    {
      return ((FluentItem<StackPanel>)item).Element;
    }
  }
}
