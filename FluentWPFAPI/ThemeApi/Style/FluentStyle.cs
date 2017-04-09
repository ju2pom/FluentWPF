using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi.Trigger;

//using System.Windows.Interactivity;
//using TriggerAction = System.Windows.Interactivity.TriggerAction;

namespace FluentWPFAPI.ThemeApi.Style
{
  internal class FluentStyle : System.Windows.Style, IFluentStyle, IInternalFluentStyle
  {
    private readonly System.Windows.Style style;

    public FluentStyle()
    {
      this.style = new System.Windows.Style();
    }

    System.Windows.Style IInternalFluentStyle.Style => this.style;

    public void SetTemplate(ControlTemplate template)
    {
      this.style.Setters.Add(new Setter(Control.TemplateProperty, template));
    }

    public void AddSetter(DependencyProperty property, object value)
    {
      this.style.Setters.Add(new Setter(property, value));
    }

    public void Extend(IFluentStyle basedOnStyle)
    {
      this.style.BasedOn = (basedOnStyle as IInternalFluentStyle)?.Style;
    }

    public void AddTrigger(IFluentTrigger fluentTrigger)
    {
      FluentTrigger trigger = (fluentTrigger as FluentTrigger);
      this.style.Triggers.Add(trigger);
    }

    public void Apply(FrameworkElement element)
    {
      element.Style = this.style;
    }
  }
}