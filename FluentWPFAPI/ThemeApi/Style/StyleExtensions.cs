using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi.Style
{
  public static class StyleExtensions
  {
    public static IFluentStyle Create()
    {
      return new FluentStyle();
    }

    public static IFluentStyle Set(this IFluentStyle fluentStyle, DependencyProperty property, object value)
    {
      fluentStyle.AddSetter(property, value);

      return fluentStyle;
    }

    public static IFluentStyle Template(this IFluentStyle fluentStyle, ControlTemplate template)
    {
      fluentStyle.Set(Control.TemplateProperty, template);

      return fluentStyle;
    }

    public static IFluentTrigger When(this IFluentStyle fluentStyle, DependencyProperty property)
    {
      return fluentStyle.AddTrigger(property);
    }

    public static IFluentTrigger Is(this IFluentTrigger fluentTrigger, object value)
    {
      fluentTrigger.SetValue(value);

      return fluentTrigger;
    }

/*    public static IFluentTrigger When<T>(this IFluentStyle fluentStyle, Func<T, bool> predicate)
      where T : FrameworkElement
    {
      var fluentTrigger = fluentStyle.AddTrigger(Control.TagProperty);
      fluentTrigger.SetValue(predicate);

      return fluentTrigger;
    }

    public static IFluentStyle<T> Call<T>(this IFluentTrigger fluentTrigger, Action<T> action)
      where T : FrameworkElement
    {
      fluentTrigger.AddCallback(action);

      return (fluentTrigger as FluentTrigger<T>)?.FluentStyle;
    }
    */

    public static IFluentTrigger Then(this IFluentTrigger fluentTrigger, DependencyProperty property, object value)
    {
      fluentTrigger.AddSetter(property, value);

      return fluentTrigger;
    }

    public static IFluentStyle EndWhen(this IFluentTrigger fluentTrigger)
    {
      return (fluentTrigger as FluentTrigger).FluentStyle;
    }

    public static System.Windows.Style AsStyle<T>(this IFluentStyle fluentStyle)
      where T : FrameworkElement
    {
      System.Windows.Style style = (fluentStyle as IInternalFluentStyle).Style;
      style.TargetType = typeof(T);

      return style;
    }
  }
}