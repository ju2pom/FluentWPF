using System.Collections.Generic;
using System.Windows;
using FluentWPFAPI.ThemeApi.Triggers;

namespace FluentWPFAPI.ThemeApi.Style
{
  public interface IFluentStyle
  {
    IEnumerable<Setter> Setters { get; }

    IEnumerable<IFluentTrigger> Triggers { get; }

    void Extend(IFluentStyle basedOnStyle);

    void AddSetter(DependencyProperty property, object value);

    void AddTrigger(IFluentTrigger fluentTrigger);
  }
}
