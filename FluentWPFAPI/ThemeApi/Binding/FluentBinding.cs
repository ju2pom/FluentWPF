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

    public object Source { get; set; }

    public PropertyPath Path { get; set; }

    public BindingMode Mode { get; set; }

    public IValueConverter Converter { get; set; }

    public RelativeSource RelativeSource { get; set; }

    public void Bind(FrameworkElement element, object source)
    {
      this.Source = this.Source ?? source;

      System.Windows.Data.Binding binding = new System.Windows.Data.Binding
      {
        Source = this.Source,
        Path = this.Path,
        Mode = this.Mode,
        Converter = this.Converter,
      };

      if (this.Source == null && this.RelativeSource != null)
      {
        RelativeSource = this.RelativeSource;
      }

      BindingOperations.SetBinding(element, this.property, binding);
    }
  }
}