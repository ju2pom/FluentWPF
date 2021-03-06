using System;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.ThemeApi.Template
{
  public class FluentTemplateItem : IFluentTemplateItem
  {
    private readonly FrameworkElementFactory itemFactory;

    public FluentTemplateItem(Type elementType)
    {
      this.itemFactory = new FrameworkElementFactory(elementType);
    }

    public void AddChild(IFluentTemplateItem child)
    {
      this.itemFactory.AppendChild((child as FluentTemplateItem).GetFactory());
    }

    public void Binding(DependencyProperty property, object value, IValueConverter converter, object targetNullValue)
    {
      System.Windows.Data.Binding b;
      string path = value as string;
      if (path != null)
      {
        b = new System.Windows.Data.Binding(path);
      }
      else
      {
        b = new System.Windows.Data.Binding();
        DependencyProperty templateProperty = value as DependencyProperty;
        b.Path = new PropertyPath(templateProperty);
        b.RelativeSource = RelativeSource.TemplatedParent;
      }

      if (targetNullValue != null)
      {
        b.TargetNullValue = targetNullValue;
      }

      b.Converter = converter;
      this.itemFactory.SetBinding(property, b);
    }

    public void SetValue(DependencyProperty property, object value)
    {
      this.itemFactory.SetValue(property, value);
    }

    internal virtual FrameworkElementFactory GetFactory()
    {
      return this.itemFactory;
    }
  }
}