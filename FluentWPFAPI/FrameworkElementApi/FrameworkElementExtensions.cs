using System;
using System.Windows;

using System.Linq.Expressions;
using System.Reflection;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPFAPI.FrameworkElementApi
{
  public static class FrameworkElementExtensions
  {
    public static IFluentItem<T> Set<T>(this IFluentItem<T> item, DependencyProperty property, object value)
      where T : FrameworkElement
    {
      Get(item).SetValue(property, value);

      return item;
    }

    public static IFluentItem<T> Set<T>(this IFluentItem<T> item, Expression<Func<T, object>> expression, object value)
  where T : FrameworkElement
    {
      var memberSelectorExpression = expression.Body as MemberExpression;
      if (memberSelectorExpression != null)
      {
        var property = memberSelectorExpression.Member as PropertyInfo;
        if (property != null)
        {
          property.SetValue(Get(item), value, null);
        }
      }

      return item;
    }

    public static IFluentItem<T> UseStyle<T>(this IFluentItem<T> item, string key)
      where T : FrameworkElement
    {
      Get(item).Style = Application.Current.Resources[key] as Style;

      return item;
    }

    public static IFluentItem<T> UseStyle<T>(this IFluentItem<T> item, Style style)
      where T : FrameworkElement
    {
      Get(item).Style = style;

      return item;
    }

    public static IFluentItem<T> UseStyle<T>(this IFluentItem<T> item, IFluentStyle style)
      where T : FrameworkElement
    {
      style.Apply(Get(item));

      return item;
    }

    public static IFluentItem<T> Center<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).HorizontalAlignment = HorizontalAlignment.Center;
      Get(item).VerticalAlignment = VerticalAlignment.Center;

      return item;
    }

    public static IFluentItem<T> Stretch<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).HorizontalAlignment = HorizontalAlignment.Stretch;
      Get(item).VerticalAlignment = VerticalAlignment.Stretch;

      return item;
    }

    public static IFluentItem<T> Top<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).VerticalAlignment = VerticalAlignment.Top;

      return item;
    }

    public static IFluentItem<T> CenterVertically<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).VerticalAlignment = VerticalAlignment.Center;

      return item;
    }

    public static IFluentItem<T> Bottom<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).VerticalAlignment = VerticalAlignment.Bottom;

      return item;
    }

    public static IFluentItem<T> StretchVertically<T>(this IFluentItem<T> item)
  where T : FrameworkElement
    {
      Get(item).VerticalAlignment = VerticalAlignment.Stretch;

      return item;
    }

    public static IFluentItem<T> Left<T>(this IFluentItem<T> item)
   where T : FrameworkElement
    {
      Get(item).HorizontalAlignment = HorizontalAlignment.Left;

      return item;
    }

    public static IFluentItem<T> CenterHorizontally<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).HorizontalAlignment = HorizontalAlignment.Center;

      return item;
    }

    public static IFluentItem<T> Right<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).HorizontalAlignment = HorizontalAlignment.Right;

      return item;
    }

    public static IFluentItem<T> StretchHorizontal<T>(this IFluentItem<T> item)
      where T : FrameworkElement
    {
      Get(item).HorizontalAlignment = HorizontalAlignment.Stretch;

      return item;
    }

    public static IFluentItem<T> MarginLeft<T>(this IFluentItem<T> item, double left)
      where T : FrameworkElement
    {
      T element = Get(item);
      Thickness margin = element.Margin;
      element.Margin = new Thickness(left, margin.Top, margin.Right, margin.Bottom);

      return item;
    }

    public static IFluentItem<T> MarginTop<T>(this IFluentItem<T> item, double top)
      where T : FrameworkElement
    {
      T element = Get(item);
      Thickness margin = element.Margin;
      element.Margin = new Thickness(margin.Left, top, margin.Right, margin.Bottom);

      return item;
    }

    public static IFluentItem<T> MarginRight<T>(this IFluentItem<T> item, double right)
      where T : FrameworkElement
    {
      T element = Get(item);
      Thickness margin = element.Margin;
      element.Margin = new Thickness(margin.Left, margin.Top, right, margin.Bottom);

      return item;
    }

    public static IFluentItem<T> MarginBottom<T>(this IFluentItem<T> item, double bottom)
      where T : FrameworkElement
    {
      T element = Get(item);
      Thickness margin = element.Margin;
      element.Margin = new Thickness(margin.Left, margin.Top, margin.Right, bottom);

      return item;
    }

    public static IFluentItem<T> Margin<T>(this IFluentItem<T> item, double left, double top, double right, double bottom)
      where T : FrameworkElement
    {
      T element = Get(item);
      element.Margin = new Thickness(left, top, right, bottom);

      return item;
    }

    public static IFluentItem<T> Margin<T>(this IFluentItem<T> item, Thickness margin)
      where T : FrameworkElement
    {
      Get(item).Margin = margin;

      return item;
    }

    public static IFluentItem<T> Margin<T>(this IFluentItem<T> item, float margin)
  where T : FrameworkElement
    {
      Get(item).Margin = new Thickness(margin);

      return item;
    }

    private static T Get<T>(IFluentItem<T> item)
    {
      return ((IInternalFluentItem<T>) item).Element;
    }
  }
}
