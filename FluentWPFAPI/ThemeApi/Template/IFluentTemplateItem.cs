using System.Windows;

namespace FluentWPFAPI.ThemeApi.Template
{
 
  public interface IFluentTemplateItem
  {
    void AddChild(IFluentTemplateItem child);

    void Binding(DependencyProperty property, object value);
  }
}