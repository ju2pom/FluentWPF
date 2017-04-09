using System.Collections.Generic;
using System.Windows;

namespace FluentWPFAPI.ThemeApi.Triggers
{
  internal class FluentTrigger : IFluentTrigger
  {
    private readonly List<Setter> setters;

    public FluentTrigger(DependencyProperty property)
    {
      this.Property = property;
      this.setters = new List<Setter>();
    }

    public DependencyProperty Property { get; }

    public object Value { get; set; }

    public IEnumerable<Setter> Setters => this.setters;

    public void AddSetter(DependencyProperty p, object v)
    {
      this.setters.Add(new Setter(p, v));
    }
  }
}