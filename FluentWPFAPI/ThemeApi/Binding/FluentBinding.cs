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

    public RelativeSource RelativeSource { get; private set; }

    public void SetRelative(RelativeSourceMode mode, DependencyProperty property)
    {
      this.RelativeSource = new RelativeSource(mode);
      this.Path = new PropertyPath(property);
    }

    public void Bind(FrameworkElement element, object source)
    {
      this.Source = this.Source ?? source;

      System.Windows.Data.Binding binding = new System.Windows.Data.Binding
      {
        Path = this.Path,
        Mode = this.Mode,
        Converter = this.Converter,
      };

      if (this.RelativeSource != null)
      {
        binding.RelativeSource = this.RelativeSource;
      }
      else
      {
        binding.Source = this.Source;
      }

      BindingOperations.SetBinding(element, this.property, binding);
    }
  }
}