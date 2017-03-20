using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.ThemeApi
{
  internal class FluentStyle : IFluentStyle, IInternalFluentStyle
  {
    private readonly Style style;

    private Trigger currentTrigger;

    public FluentStyle()
    {
      this.style = new Style();
    }

    Style IInternalFluentStyle.Style => this.style;

    public void SetTemplate(ControlTemplate template)
    {
      this.style.Setters.Add(new Setter(Control.TemplateProperty, template));
    }

    public void Apply(FrameworkElement element)
    {
      element.Style = this.style;
    }

    public void AddSetter(DependencyProperty property, object value)
    {
      if (this.currentTrigger == null)
      {
        this.style.Setters.Add(new Setter(property, value));
      }
      else
      {
        this.currentTrigger.Setters.Add(new Setter(property, value));
      }
    }

    public void StartTrigger(DependencyProperty property, object value)
    {
      this.currentTrigger = new Trigger
      {
        Property = property,
        Value = value
      };
    }

    public void EndTrigger()
    {
      if (this.currentTrigger != null)
      {
        this.style.Triggers.Add(this.currentTrigger);
        this.currentTrigger = null;
      }
    }

    public void BasedOn(IFluentStyle basedOnStyle)
    {
      this.style.BasedOn = (basedOnStyle as IInternalFluentStyle)?.Style;
    }

    public void SetTargetType(Type targetType)
    {
      this.style.TargetType = targetType;
    }
  }
}