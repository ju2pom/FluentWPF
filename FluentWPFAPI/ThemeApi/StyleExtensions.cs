using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
  public static class StyleExtensions
  {
    public static IFluentStyle Style()
    {
      return new FluentStyle();
    }

    public static IFluentStyle Targets<T>(this IFluentStyle fluentStyle)
      where T : FrameworkElement
    {
      fluentStyle.SetTargetType(typeof(T));

      return fluentStyle;
    }

    public static IFluentStyle Condition(this IFluentStyle fluentStyle, DependencyProperty property, object value)
    {
      fluentStyle.StartTrigger(property, value);

      return fluentStyle;
    }

    public static IFluentStyle Set(this IFluentStyle fluentStyle, DependencyProperty property, object value)
    {
      fluentStyle.AddSetter(property, value);

      return fluentStyle;
    }

    public static IFluentStyle EndCondition(this IFluentStyle fluentStyle)
    {
      fluentStyle.EndTrigger();

      return fluentStyle;
    }

    public static IFluentStyle Template(this IFluentStyle fluentStyle, ControlTemplate template)
    {
      fluentStyle.SetTemplate(template);

      return fluentStyle;
    }
  }
}