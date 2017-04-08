using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi.Template
{
  public class FluentTemplateItemWithChild : FluentTemplateItem, IFluentTemplateItemWithChild
  {
    private readonly List<IFluentTemplateItem> children;

    public FluentTemplateItemWithChild(Type elementType)
      : base(elementType)
    {
      if (!elementType.IsSubclassOf(typeof(Panel)))
      {
        throw new ArgumentException(nameof(elementType), "Must be a type deriving from Panel");
      }

      this.children = new List<IFluentTemplateItem>();
    }

    public void Add(IFluentTemplateItem item)
    {
      this.children.Add(item);
    }

    internal override FrameworkElementFactory GetFactory()
    {
      FrameworkElementFactory elementFactory = base.GetFactory();

      foreach (var child in this.children.OfType<FluentTemplateItem>())
      {
        elementFactory.AppendChild(child.GetFactory());
      }

      return elementFactory;
    }
  }
}