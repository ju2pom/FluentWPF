using System;
using System.Windows;
using System.Windows.Data;
using FluentWPFAPI.Converters;

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

    public void Binding(DependencyProperty property, object value, IValueConverter converter)
    {
      DependencyProperty templateProperty = value as DependencyProperty;
      if (templateProperty != null)
      {
        System.Windows.Data.Binding b = new System.Windows.Data.Binding();
        b.RelativeSource = RelativeSource.TemplatedParent;
        b.Path = new PropertyPath(templateProperty);
        b.Converter = converter;

        /*var bindingExtension = new TemplateBindingExtension(templateProperty);
        if (converter != null)
        {
          bindingExtension.Converter = new LambdaConverter(converter);
        }

        this.itemFactory.SetValue(property, bindingExtension);*/
        this.itemFactory.SetBinding(property, b);

      }
      else
      {
        this.itemFactory.SetValue(property, value);
      }
    }

    internal virtual FrameworkElementFactory GetFactory()
    {
      return this.itemFactory;
    }
  }
}