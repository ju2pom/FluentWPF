using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi.Triggers;

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

    public static IFluentStyle When(this IFluentStyle fluentStyle, IFluentTrigger fluentTrigger)
    {
      fluentStyle.AddTrigger(fluentTrigger);

      return fluentStyle;
    }

    public static System.Windows.Style AsStyle<T>(this IFluentStyle fluentStyle)
      where T : FrameworkElement
    {
      System.Windows.Style style = new System.Windows.Style();
      style.TargetType = typeof(T);

      foreach (IFluentTrigger trigger in fluentStyle.Triggers)
      {
        style.Triggers.Add(trigger.AsTrigger());
      }

      foreach (Setter setter in fluentStyle.Setters)
      {
        style.Setters.Add(setter);
      }

      return style;
    }
  }
}