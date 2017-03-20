using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.BindingApi
{
  public static class BindingApi
  {
    public static IFluentItem<T> Bind<T>(this IFluentItem<T> item, DependencyProperty property, string path, BindingMode mode = BindingMode.Default)
      where T : FrameworkElement
    {
      FluentItem<T> fluentItem = (FluentItem<T>)item;

      Binding binding = new Binding
      {
        Source = fluentItem.Element.DataContext,
        Path = new PropertyPath(path),
        Mode = mode,
      };


      fluentItem.AddBinding(new FluentBinding(fluentItem.Element, property, binding));

      return item;
    }

    public static IFluentItem<T> Bind<T>(this IFluentItem<T> item, DependencyProperty property, object source, BindingMode mode = BindingMode.Default)
      where T : FrameworkElement
    {
      FluentItem<T> fluentItem = (FluentItem<T>)item;

      Binding binding = new Binding
      {
        Source = source,
        Mode = mode,
      };


      fluentItem.AddBinding(new FluentBinding(fluentItem.Element, property, binding));

      return item;
    }
  }
}