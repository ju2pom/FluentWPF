using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
  public static class StyleExtensions
  {
    public static IFluentStyle<T> Style<T>()
      where T : FrameworkElement
    {
      return new FluentStyle<T>();
    }

    public static IFluentStyle<T> Set<T>(this IFluentStyle<T> fluentStyle, DependencyProperty property, object value)
      where T : FrameworkElement
    {
      fluentStyle.AddSetter(property, value);

      return fluentStyle;
    }

    public static IFluentStyle<T> Template<T>(this IFluentStyle<T> fluentStyle, ControlTemplate template)
      where T : FrameworkElement
    {
      fluentStyle.SetTemplate(template);

      return fluentStyle;
    }

    public static Style Get<T>(this IFluentStyle<T> fluentStyle)
      where T : FrameworkElement
    {
      IInternalFluentStyle internalFluentStyle = fluentStyle as IInternalFluentStyle;

      return internalFluentStyle?.Style;
    }

    public static IFluentTrigger<T> When<T>(this IFluentStyle<T> fluentStyle, DependencyProperty property)
      where T : FrameworkElement
    {
      return fluentStyle.AddTrigger(property);
    }

    public static IFluentTrigger<T> Is<T>(this IFluentTrigger<T> fluentTrigger, object value)
      where T : FrameworkElement
    {
      fluentTrigger.SetValue(value);

      return fluentTrigger;
    }

    public static IFluentTrigger<T> When<T>(this IFluentStyle<T> fluentStyle, Func<T, bool> predicate)
  where T : FrameworkElement
    {
      var fluentTrigger = fluentStyle.AddTrigger(Control.TagProperty);
      fluentTrigger.SetValue(predicate);

      return fluentTrigger;
    }

    public static IFluentStyle<T> Call<T>(this IFluentTrigger<T> fluentTrigger, Action<T> action)
      where T : FrameworkElement
    {
      fluentTrigger.AddCallback(action);

      return (fluentTrigger as FluentTrigger<T>)?.FluentStyle;
    }

    public static IFluentTrigger<T> Then<T>(this IFluentTrigger<T> fluentTrigger, DependencyProperty property, object value)
      where T : FrameworkElement
    {
      fluentTrigger.AddSetter(property, value);

      return fluentTrigger;
    }

    public static IFluentStyle<T> EndWhen<T>(this IFluentTrigger<T> fluentTrigger)
      where T : FrameworkElement
    {
      return (fluentTrigger as FluentTrigger<T>).FluentStyle;
    }
  }
}