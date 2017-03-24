using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
  public static class TemplateExtensions
  {
    public static IFluentTemplate<T> Template<T>()
      where T : FrameworkElement
    {
      return new FluentTemplate<T>();
    }

    public static IFluentTemplate<T> Bind<T>(this IFluentTemplate<T> template, DependencyProperty property, DependencyProperty templateProperty)
      where T : FrameworkElement
    {
      return template.Set(property, templateProperty);
    }

    public static IFluentTemplate<T> Set<T>(this IFluentTemplate<T> template, DependencyProperty property, object value)
      where T : FrameworkElement
    {
      template.Binding(property, value);

      return template;
    }

    public static IFluentTemplate<T> Factory<T, U>(this IFluentTemplate<T> template)
      where U : FrameworkElement where T : FrameworkElement
    {
      FrameworkElementFactory controlFactory = new FrameworkElementFactory(typeof(U));
      template.Factory(controlFactory);

      return template;
    }

    public static ControlTemplate Get<T>(this IFluentTemplate<T> template)
    {
      return (template as FluentTemplate<T>)?.Template;
    }
  }
}
