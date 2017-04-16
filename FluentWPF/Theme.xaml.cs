using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Color;

namespace FluentWPF
{
  public partial class Theme : FluentTheme
  {
    public static IThemeColors ThemeColors;

    static Theme()
    {
      ThemeColors = GetColors();
    }
    public Theme()
    {
      this.InitializeComponent();

      FluentTheme.Load(this, ThemeColors);
    }

    public override IEnumerable<Style> GetDefaultStyles(IThemeColors themeColors)
    {
      yield return this.GetWindowStyle(themeColors);
      yield return this.GetButtonStyle(themeColors);
      yield return this.GetCheckBoxStyle(themeColors);
      yield return this.GetHeaderContentControlStyle(themeColors);
    }

    private static IThemeColors GetColors()
    {
      return new ThemeColors()
        .Text(new ColorPack()
          .Normal(Colors.Black))
        .Control(new ColorPack()
          .Normal(Color.FromRgb(30,40,48))
          .Over(Color.FromRgb(75,83,88))
          .Accent1(Color.FromRgb(126, 187, 69))
          .Accent2(Color.FromRgb(233, 100, 68)))
        .Outline(new ColorPack()
          .Normal(Colors.Black));
    }
  }
}
