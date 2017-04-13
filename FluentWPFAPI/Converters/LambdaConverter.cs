using System;
using System.Globalization;
using System.Windows.Data;

namespace FluentWPFAPI.Converters
{
  public class LambdaConverter : IValueConverter
  {
    private readonly Func<object, object> convertBack;
    private readonly Func<object, object> convert;

    public LambdaConverter(Func<object, object> convert, Func<object, object> convertBack = null)
    {
      this.convert = convert;
      this.convertBack = convertBack;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (this.convert != null)
      {
        return this.convert(value);
      }

      return Binding.DoNothing;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (this.convertBack != null)
      {
        return this.convertBack(value);
      }

      return Binding.DoNothing;
    }
  }
}
