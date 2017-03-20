using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI
{
  internal interface IFluentBinding
  {
  }

  internal class FluentBinding : IFluentBinding
  {
    private readonly FrameworkElement _element;
    private readonly DependencyProperty _property;
    private readonly Binding _binding;

    public FluentBinding(FrameworkElement element, DependencyProperty property, Binding binding)
    {
      _element = element;
      _property = property;
      _binding = binding;
    }

    public void Apply()
    {
      this._binding.Source = _element.DataContext;
      BindingOperations.SetBinding(_element, _property, _binding);
    }
  }
}