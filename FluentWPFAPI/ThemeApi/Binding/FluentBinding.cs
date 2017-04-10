using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.ThemeApi.Binding
{
  internal class FluentBinding : IFluentBinding
  {
    private readonly DependencyProperty property;

    public FluentBinding(DependencyProperty property)
    {
      this.property = property;
    }

    public PropertyPath Path { get; set; }

    public BindingMode Mode { get; set; }

    public IValueConverter Converter { get; set; }

    public System.Windows.Data.Binding AsBinding(FrameworkElement element)
    {
      System.Windows.Data.Binding binding = new System.Windows.Data.Binding
      {
        Source = element.DataContext,
        Path = this.Path,
        Mode = this.Mode,
        Converter = this.Converter,
      };

      BindingOperations.SetBinding(element, this.property, binding);

      return binding;
    }
  }
}