using System;
using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.ThemeApi.Template
{
 
  public interface IFluentTemplateItem
  {
    void AddChild(IFluentTemplateItem child);

    void Binding(DependencyProperty property, object value, IValueConverter converter = null);
  }
}