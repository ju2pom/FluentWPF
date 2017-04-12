using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FluentWPFAPI.ButtonApi
{
  public static class ButtonExtensions
  {
    public static IFluentItem<Button> ClickAction(this IFluentItem<Button> item, RoutedEventHandler handler)
    {
      item.Element.Click += handler;

      return item;
    }

    public static IFluentItem<CheckBox> OnCheckAction(this IFluentItem<CheckBox> item, RoutedEventHandler handler)
    {
      item.Element.Checked += handler;

      return item;
    }

    public static IFluentItem<ToggleButton> OnCheckAction(this IFluentItem<ToggleButton> item, RoutedEventHandler handler)
    {
      item.Element.Checked += handler;

      return item;
    }
  }
}