using System.Linq;
using System.Windows;

namespace FluentWPFAPI.ThemeApi.Triggers
{
  public static class TriggerExtensions
  {
    public static IFluentTrigger Property(DependencyProperty property)
    {
      return new FluentTrigger(property);
    }

    public static IFluentTrigger Is(this IFluentTrigger fluentTrigger, object value)
    {
      fluentTrigger.Value = value;

      return fluentTrigger;
    }

    public static IFluentTrigger Then(this IFluentTrigger fluentTrigger, DependencyProperty property, object value)
    {
      fluentTrigger.AddSetter(property, value);

      return fluentTrigger;
    }

    public static Trigger AsTrigger(this IFluentTrigger fluentTrigger)
    {
      Trigger trigger = new Trigger { Property = fluentTrigger.Property, Value = fluentTrigger.Value };

      fluentTrigger.Setters.ToList().ForEach(x => trigger.Setters.Add(x));

      return trigger;
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
  }
}
