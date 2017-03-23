using System;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Interactivity;
//using TriggerAction = System.Windows.Interactivity.TriggerAction;

namespace FluentWPFAPI.ThemeApi
{
  internal class FluentStyle<T> : Style, IFluentStyle<T>, IInternalFluentStyle
    where T : FrameworkElement
  {
    private readonly Style style;

    public FluentStyle()
    {
      this.style = new Style();
    }

    Style IInternalFluentStyle.Style => this.style;

    public void SetTemplate(ControlTemplate template)
    {
      this.style.Setters.Add(new Setter(Control.TemplateProperty, template));
    }

    public void Apply(T element)
    {
      element.Style = this.style;
    }

    public void AddSetter(DependencyProperty property, object value)
    {
      this.style.Setters.Add(new Setter(property, value));
    }

    public void BasedOn<U>(IFluentStyle<U> basedOnStyle) where U : FrameworkElement
    {
      this.style.BasedOn = (basedOnStyle as IInternalFluentStyle)?.Style;
    }

    public IFluentTrigger<T> AddTrigger(DependencyProperty property)
    {
      FluentTrigger<T> trigger = new FluentTrigger<T>(this)
      {
        Property = property
      };

      this.style.Triggers.Add(trigger);

      return trigger;
    }
  }

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