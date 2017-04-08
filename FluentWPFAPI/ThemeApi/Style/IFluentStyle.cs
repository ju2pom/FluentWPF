using System;
using System.Windows;

namespace FluentWPFAPI.ThemeApi.Style
{
  internal interface IInternalFluentStyle
  {
    System.Windows.Style Style { get; }
  }

  public interface IFluentStyle
  {
    void Extend(IFluentStyle basedOnStyle);

    void AddSetter(DependencyProperty property, object value);

    IFluentTrigger AddTrigger(DependencyProperty property);

    void Apply(FrameworkElement element);
  }

  public interface IFluentTrigger
  {
    void SetProperty(DependencyProperty property);

    void SetValue(object value);

    void AddSetter(DependencyProperty property, object value);

    //void AddCallback<T>(Action<T> action);
  }
}
