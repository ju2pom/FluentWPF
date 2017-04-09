using System.Collections.Generic;
using System.Windows;

namespace FluentWPFAPI.ThemeApi.Triggers
{
  public interface IFluentTrigger
  {
    DependencyProperty Property { get; }

    object Value { get; set; }

    IEnumerable<Setter> Setters { get; }

    void AddSetter(DependencyProperty property, object value);
  }
}