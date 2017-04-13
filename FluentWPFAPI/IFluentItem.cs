using System.Windows;
using FluentWPFAPI.ThemeApi.Binding;

namespace FluentWPFAPI
{
  public interface IFluentItem
  {
    FrameworkElement Element { get; }

    void AddChild(IFluentItem child);

    void AddBinding(IFluentBinding binding);

    void AddHandler(RoutedEvent ev, RoutedEventHandler handler);

    void Initialize(object dataContext);
  }

  public interface IFluentItem<T> : IFluentItem
    where T : FrameworkElement
  {
    new T Element { get; }

    new T Initialize(object dataContext);
  }
}