using System;
using System.Windows;
using System.Windows.Data;
using FluentWPFAPI.Converters;

namespace FluentWPFAPI.ThemeApi.Binding
{
  public static class BindingExtensions
  {
    public static IFluentBinding Property(DependencyProperty property)
    {
      FluentBinding fluentBinding = new FluentBinding(property);

      return fluentBinding;
    }

    public static IFluentBinding OneWay(this IFluentBinding fluentBinding, string path)
    {
      Bind(fluentBinding, path, BindingMode.OneWay);

      return fluentBinding;
    }

    public static IFluentBinding TwoWay(this IFluentBinding fluentBinding, string path)
    {
      Bind(fluentBinding, path, BindingMode.TwoWay);

      return fluentBinding;
    }

    public static IFluentBinding OneWayToSource(this IFluentBinding fluentBinding, string path)
    {
      Bind(fluentBinding, path, BindingMode.OneWayToSource);

      return fluentBinding;
    }

    public static IFluentBinding OneTime(this IFluentBinding fluentBinding, string path)
    {
      Bind(fluentBinding, path, BindingMode.OneTime);

      return fluentBinding;
    }

    public static IFluentBinding Convert(this IFluentBinding fluentBinding, Func<object, object> convert)
    {
      fluentBinding.Converter = new LambdaConverter(convert);

      return fluentBinding;
    }

    private static void Bind(IFluentBinding fluentBinding, string path, BindingMode mode)
    {
      fluentBinding.Mode = mode;
      fluentBinding.Path = new PropertyPath(path);
    }
  }
}
