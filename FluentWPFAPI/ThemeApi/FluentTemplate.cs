using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
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