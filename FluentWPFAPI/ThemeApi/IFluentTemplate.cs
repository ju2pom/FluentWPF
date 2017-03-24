using System.Windows;

namespace FluentWPFAPI.ThemeApi
{
  public interface IFluentTemplate<T>
  {
    IFluentTemplate<T> Factory(FrameworkElementFactory factory);

    void Binding(DependencyProperty property, object value);
  }
}