using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
  internal interface IInternalFluentStyle
  {
    Style Style { get; }
  }

  public interface IFluentStyle
  {
    void SetTargetType(Type targetType);

    void BasedOn(IFluentStyle basedOnStyle);

    void Apply(FrameworkElement element);

    void SetTemplate(ControlTemplate template);

    void AddSetter(DependencyProperty property, object value);

    void StartTrigger(DependencyProperty property, object value);

    void EndTrigger();
  }
}
