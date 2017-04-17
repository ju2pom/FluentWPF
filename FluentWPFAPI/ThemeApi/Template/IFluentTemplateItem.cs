using System;
using System.Windows;

namespace FluentWPFAPI.ThemeApi.Template
{
 
  public interface IFluentTemplateItem
  {
    void AddChild(IFluentTemplateItem child);

    void Binding(DependencyProperty property, object value, Func<object, object> converter = null);
  }
}