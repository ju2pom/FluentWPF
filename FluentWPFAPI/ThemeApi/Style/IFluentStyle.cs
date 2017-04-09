﻿using System.Windows;
using FluentWPFAPI.ThemeApi.Trigger;

namespace FluentWPFAPI.ThemeApi.Style
{
  public interface IFluentStyle
  {
    void Extend(IFluentStyle basedOnStyle);

    void AddSetter(DependencyProperty property, object value);

    void AddTrigger(IFluentTrigger fluentTrigger);

    void Apply(FrameworkElement element);
  }
}
