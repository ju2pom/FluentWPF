using System;
using System.Windows;

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

    public void Binding(DependencyProperty property, object value)
    {
      DependencyProperty templateProperty = value as DependencyProperty;
      if (templateProperty != null)
      {
        this.itemFactory.SetValue(property, new TemplateBindingExtension(templateProperty));
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