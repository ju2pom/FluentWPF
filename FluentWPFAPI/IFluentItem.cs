using System.Windows;

namespace FluentWPFAPI
{
  public interface IFluentItem
  {
    FrameworkElement Element { get; }

    void Initialize();
  }

  public interface IFluentItem<T> : IFluentItem
    where T : FrameworkElement
  {
    new T Element { get; }

    new T Initialize();
  }
}