using System.Windows.Media;

namespace FluentWPFAPI.ThemeApi.Color
{
  public static class ColorPackExtensions
  {
    public static IColorPack Accent1(this IColorPack colorPack, System.Windows.Media.Color color)
    {
      colorPack.Accent1 = new SolidColorBrush(color);

      return colorPack;
    }

    public static IColorPack Accent2(this IColorPack colorPack, System.Windows.Media.Color color)
    {
      colorPack.Accent2 = new SolidColorBrush(color);

      return colorPack;
    }

    public static IColorPack Normal(this IColorPack colorPack, System.Windows.Media.Color color)
    {
      colorPack.Normal = new SolidColorBrush(color);

      return colorPack;
    }

    public static IColorPack Disabled(this IColorPack colorPack, System.Windows.Media.Color color)
    {
      colorPack.Disabled = new SolidColorBrush(color);

      return colorPack;
    }

    public static IColorPack Over(this IColorPack colorPack, System.Windows.Media.Color color)
    {
      colorPack.Over = new SolidColorBrush(color);

      return colorPack;
    }

    public static IColorPack Selected(this IColorPack colorPack, System.Windows.Media.Color color)
    {
      colorPack.Selected = new SolidColorBrush(color);

      return colorPack;
    }
  }
}
