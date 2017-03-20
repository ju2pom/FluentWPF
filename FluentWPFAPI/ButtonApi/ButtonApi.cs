using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FluentWPFAPI.ButtonApi
{
  public static class ButtonApi
  {
    public static IFluentItem<Button> ClickAction(this IFluentItem<Button> item, RoutedEventHandler handler)
    {
      IInternalFluentItem<Button> fluentItem = (IInternalFluentItem<Button>)item;
      fluentItem.Element.Click += handler;

      return item;
    }

    public static IFluentItem<CheckBox> OnCheckAction(this IFluentItem<CheckBox> item, RoutedEventHandler handler)
    {
      IInternalFluentItem<CheckBox> fluentItem = (IInternalFluentItem<CheckBox>)item;
      fluentItem.Element.Checked += handler;

      return item;
    }

    public static IFluentItem<ToggleButton> OnCheckAction(this IFluentItem<ToggleButton> item, RoutedEventHandler handler)
    {
      IInternalFluentItem<ToggleButton> fluentItem = (IInternalFluentItem<ToggleButton>)item;
      fluentItem.Element.Checked += handler;

      return item;
    }
  }
}