using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi.Template
{
  public static class TemplateExtensions
  {
    public static IFluentTemplateItem Create<T>()
      where T : FrameworkElement
    {
      return new FluentTemplateItem(typeof(T));
    }

    public static IFluentTemplateItem Contains<T>(this IFluentTemplateItem templateItem)
      where T : FrameworkElement
    {
      FluentTemplateItem child = new FluentTemplateItem(typeof(T));

      templateItem.Contains(child);

      return child;
    }

    public static IFluentTemplateItem Contains(this IFluentTemplateItem templateItem, IFluentTemplateItem child)
    {
      templateItem.AddChild(child);

      return templateItem;
    }


    public static IFluentTemplateItem TemplateBinding(this IFluentTemplateItem templateItem, DependencyProperty property, DependencyProperty templateProperty, Func<object, object> converter = null)
    {
      templateItem.Binding(property, templateProperty, converter);

      return templateItem;
    }

    public static IFluentTemplateItem Set(this IFluentTemplateItem templateItem, DependencyProperty property, object value)
    {
      templateItem.Binding(property, value);

      return templateItem;
    }

    public static IFluentTemplateItem Center(this IFluentTemplateItem templateItem)
    {
      templateItem.Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
      templateItem.Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

      return templateItem;
    }

    public static IFluentTemplateItem Size(this IFluentTemplateItem templateItem, double width, double height)
    {
      templateItem.Set(FrameworkElement.WidthProperty, width);
      templateItem.Set(FrameworkElement.HeightProperty, height);

      return templateItem;
    }

    public static ControlTemplate AsControlTemplate<T>(this IFluentTemplateItem templateItem)
      where T : FrameworkElement
    {
      FrameworkElementFactory factory = (templateItem as FluentTemplateItem)?.GetFactory();

      return new ControlTemplate(typeof(T)) { VisualTree = factory };
    }
  }
}
