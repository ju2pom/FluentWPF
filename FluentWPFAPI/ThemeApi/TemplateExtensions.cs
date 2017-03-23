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

  public interface IFluentTemplate<T>
  {
    IFluentTemplate<T> Factory(FrameworkElementFactory factory);

    void Binding(DependencyProperty property, object value);
  }

  public class FluentTemplate<T> : IFluentTemplate<T>
  {
    private FrameworkElementFactory currentFactory;

    public FluentTemplate()
    {
      this.Template = new ControlTemplate();
    }

    public ControlTemplate Template { get; }

    public IFluentTemplate<T> Factory(FrameworkElementFactory factory)
    {
      if (this.currentFactory == null)
      {
        this.Template.VisualTree = factory;
      }
      else
      {
        this.currentFactory.AppendChild(factory);
      }

      this.currentFactory = factory;

      return this;
    }

    public void Binding(DependencyProperty property, object value)
    {
      DependencyProperty templateProperty = value as DependencyProperty;
      if (templateProperty != null)
      {
        this.currentFactory.SetValue(property, new TemplateBindingExtension(templateProperty));
      }
      else
      {
        this.currentFactory.SetValue(property, value);
      }
    }
  }
}
