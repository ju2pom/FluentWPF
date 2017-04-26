using System;
using System.Collections.Generic;
using System.Windows;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPFAPI.ThemeApi.Style
{
  public interface IFluentStyle
  {
    IEnumerable<Setter> Setters { get; }

    IEnumerable<IFluentTrigger> Triggers { get; }

    Type Extends { get; }

    void Extend(IFluentStyle basedOnStyle);

    void Extend<T>() where T : FrameworkElement;

    void AddSetter(DependencyProperty property, object value);

    void AddTrigger(IFluentTrigger fluentTrigger);
  }
}
