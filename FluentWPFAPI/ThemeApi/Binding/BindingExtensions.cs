using System;
using System.Windows;
using System.Windows.Data;
using FluentWPFAPI.Converters;

namespace FluentWPFAPI.ThemeApi.Binding
{
  public static class BindingExtensions
  {
    public static IFluentBinding OneWay(DependencyProperty property)
    {
      return Create(BindingMode.OneWay, property);
    }

    public static IFluentBinding TwoWay(DependencyProperty property)
    {
      return Create(BindingMode.TwoWay, property);
    }

    public static IFluentBinding OneWayToSource(DependencyProperty property)
    {
      return Create(BindingMode.OneWayToSource, property);
    }

    public static IFluentBinding OneTime(DependencyProperty property)
    {
      return Create(BindingMode.OneTime, property);
    }

    public static IFluentBinding With(this IFluentBinding fluentBinding, string path)
    {
      fluentBinding.Path = new PropertyPath(path);

      return fluentBinding;
    }

    public static IFluentBinding Source(this IFluentBinding fluentBinding, object source)
    {
      fluentBinding.Source = source;

      return fluentBinding;
    }

    public static IFluentBinding WithSelf(this IFluentBinding fluentBinding, DependencyProperty property)
    {
      fluentBinding.RelativeSource = new RelativeSource(RelativeSourceMode.Self);

      return fluentBinding;
    }

    public static IFluentBinding Convert(this IFluentBinding fluentBinding, Func<object, object> convert)
    {
      fluentBinding.Converter = new LambdaConverter(convert);

      return fluentBinding;
    }

    public static IFluentBinding Convert(this IFluentBinding fluentBinding, IValueConverter convert)
    {
      fluentBinding.Converter = convert;

      return fluentBinding;
    }

    private static IFluentBinding Create(BindingMode mode, DependencyProperty property)
    {
      FluentBinding fluentBinding = new FluentBinding(property) {Mode = mode};

      return fluentBinding;
    }
  }
}
