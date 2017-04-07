using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
  internal interface IInternalFluentStyle
  {
    Style Style { get; }
  }

  public interface IFluentStyle<T>
    where T : FrameworkElement
  {
    void Extend<U>(IFluentStyle<U> basedOnStyle) where U : FrameworkElement;

    void Apply(T element);

    void SetTemplate(ControlTemplate template);

    void AddSetter(DependencyProperty property, object value);

    IFluentTrigger<T> AddTrigger(DependencyProperty property);
  }

  public interface IFluentTrigger<T>
  {
    void SetProperty(DependencyProperty property);

    void SetValue(object value);

    void AddSetter(DependencyProperty property, object value);

    void AddCallback(Action<T> action);
  }
}
