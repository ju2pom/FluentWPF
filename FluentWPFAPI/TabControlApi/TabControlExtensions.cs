using System.Windows.Controls;

namespace FluentWPFAPI.TabControlApi
{
  public static class TabControlExtensions
  {
    public static IFluentItem<TabControl> Tab(this IFluentItem<TabControl> fluentItem, IFluentItem<TabItem> fluentTabItem)
    {
      fluentItem.AddChild(fluentTabItem);
      fluentItem.Element.Items.Add(fluentTabItem.Element);

      return fluentItem;
    }
  }
}
