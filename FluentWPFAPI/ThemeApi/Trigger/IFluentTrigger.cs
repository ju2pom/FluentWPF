using System.Windows;

namespace FluentWPFAPI.ThemeApi.Trigger
{
  public interface IFluentTrigger
  {
    void SetProperty(DependencyProperty property);

    void SetValue(object value);

    void AddSetter(DependencyProperty property, object value);

    //void AddCallback<T>(Action<T> action);
  }
}