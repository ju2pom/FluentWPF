using System;
using System.Windows;

namespace FluentWPFAPI.ThemeApi
{
  internal class FluentTrigger<T> : Trigger, IFluentTrigger<T>
    where T : FrameworkElement
  {
    public FluentTrigger(IFluentStyle<T> fluentStyle)
    {
      this.FluentStyle = fluentStyle;
    }

    public IFluentStyle<T> FluentStyle { get; }

    public void SetProperty(DependencyProperty property)
    {
      this.Property = property;
    }

    public void SetValue(object value)
    {
      this.Value = value;
    }

    public void AddSetter(DependencyProperty property, object value)
    {
      this.Setters.Add(new Setter(property, value));
    }

    public void AddCallback(Action<T> action)
    {
    }
  }
}