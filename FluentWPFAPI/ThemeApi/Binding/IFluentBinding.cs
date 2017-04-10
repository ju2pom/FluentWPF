using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.ThemeApi.Binding
{
  public interface IFluentBinding
  {
    PropertyPath Path { get; set; }

    BindingMode Mode { get; set; }

    IValueConverter Converter { get; set; }
  }
}