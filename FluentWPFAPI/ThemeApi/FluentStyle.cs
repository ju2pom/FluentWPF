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

    public void Extend<U>(IFluentStyle<U> basedOnStyle) where U : FrameworkElement
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
}