using System.Windows;

namespace FluentWPFAPI.ThemeApi.Trigger
{
  public static class TriggerExtensions
  {
    public static IFluentTrigger Property(DependencyProperty property)
    {
      FluentTrigger fluentTrigger = new FluentTrigger(null);
      fluentTrigger.Property = property;

      return fluentTrigger;
    }

    public static IFluentTrigger Is(this IFluentTrigger fluentTrigger, object value)
    {
      fluentTrigger.SetValue(value);

      return fluentTrigger;
    }

    public static IFluentTrigger Then(this IFluentTrigger fluentTrigger, DependencyProperty property, object value)
    {
      fluentTrigger.AddSetter(property, value);

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
  }
}
