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

    public void SetValue(Func<T, bool> predicate)
    {
    }

    public void SetValue(object value)
    {
      Func<T, bool> predicate = value as Func<T, bool>;
      if (predicate != null)
      {
        value = new ActionValue(predicate);
      }

      this.Value = value;
    }

    public void AddSetter(DependencyProperty property, object value)
    {
      this.Setters.Add(new Setter(property, value));
    }

    public void AddCallback(Action<T> action)
    {
    }

    private class ActionValue : IEquatable<object>
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
    }
  }
}