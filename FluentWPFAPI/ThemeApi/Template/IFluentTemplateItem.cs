using System;
using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.ThemeApi.Template
{
 
  public interface IFluentTemplateItem
  {
    void AddChild(IFluentTemplateItem child);

    void SetValue(DependencyProperty property, object value);

    void Binding(DependencyProperty property, object value, IValueConverter converter = null);
  }
}