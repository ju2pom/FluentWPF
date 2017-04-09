using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi.Triggers;

//using System.Windows.Interactivity;
//using TriggerAction = System.Windows.Interactivity.TriggerAction;

namespace FluentWPFAPI.ThemeApi.Style
{
  internal class FluentStyle : IFluentStyle
  {
    private readonly List<Setter> setters;
    private readonly List<IFluentTrigger> triggers;

    public FluentStyle()
    {
      this.setters = new List<Setter>();
      this.triggers = new List<IFluentTrigger>();
    }

    public IEnumerable<Setter> Setters => this.setters;

    public IEnumerable<IFluentTrigger> Triggers => this.triggers;

    public void AddSetter(DependencyProperty property, object value)
    {
      this.setters.Add(new Setter(property, value));
    }

    public void AddTrigger(IFluentTrigger fluentTrigger)
    {
      this.triggers.Add(fluentTrigger);
    }

    public void Extend(IFluentStyle basedOnStyle)
    {
      this.setters.AddRange(basedOnStyle.Setters);
      this.triggers.AddRange(basedOnStyle.Triggers);
    }
  }
}