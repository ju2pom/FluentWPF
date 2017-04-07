using System.Windows.Media;
using FluentWPFAPI.ThemeApi;

namespace FluentWPF
{
  public partial class Theme : FluentTheme
  {
    private static readonly IThemeColors colors;

    static Theme()
    {
      IColorPack textColors = new ColorPack(new SolidColorBrush(Colors.Black));
      IColorPack controlColors = new ColorPack(new SolidColorBrush(Colors.DarkGray), new SolidColorBrush(Colors.LightGray));
      IColorPack outlineColors = new ColorPack(new SolidColorBrush(Colors.Black));

      colors = new ThemeColors(textColors, controlColors, outlineColors);
    }

    public Theme()
      : base(colors)
    {
      this.InitializeComponent();
    }
  }
}
