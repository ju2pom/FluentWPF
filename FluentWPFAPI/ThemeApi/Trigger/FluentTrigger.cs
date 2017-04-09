using System;
using System.Windows;
using FluentWPFAPI.ThemeApi.Style;

namespace FluentWPFAPI.ThemeApi.Trigger
{
  internal class FluentTrigger : System.Windows.Trigger, IFluentTrigger
  {
    public FluentTrigger(IFluentStyle fluentStyle)
    {
      this.FluentStyle = fluentStyle;
    }

    public IFluentStyle FluentStyle { get; }

    public void SetProperty(DependencyProperty property)
    {
      this.Property = property;
    }

    /*public void SetValue<T>(Func<T, bool> predicate)
      where T : class
    {
      this.Value = new ActionValue<T>(predicate);
    }*/

    public void SetValue(object value)
    {
      this.Value = value;
    }

    public void AddSetter(DependencyProperty property, object value)
    {
      this.Setters.Add(new Setter(property, value));
    }

    public void AddCallback<T>(Action<T> action)
    {
    }

    /*private class ActionValue<T> : IEquatable<object>
      where T : class
    {
      private readonly Func<T, bool> _predicated;

      public ActionValue(Func<T, bool> predicated)
      {
        _predicated = predicated;
      }

      public override bool Equals(object obj)
      {
        return this._predicated(obj as T);
      }

      public override int GetHashCode()
      {
        return this._predicated.GetHashCode();
      }
    }*/
  }
}