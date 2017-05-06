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
      FluentTheme.Load(this, ThemeColors);
    }

    public override IEnumerable<Style> GetDefaultStyles(IThemeColors themeColors)
    {
      yield return this.GetWindowStyle(themeColors);
      yield return this.GetButtonStyle(themeColors);
      yield return this.GetCheckBoxStyle(themeColors);
      yield return this.GetHeaderContentControlStyle(themeColors);
      yield return this.GetExpanderStyle(themeColors);
      yield return this.GetToggleButtonStyle(themeColors);
      yield return this.GetTabControlStyle(themeColors);
      yield return this.GetListBoxStyle(themeColors);
      yield return this.GetTextBlockStyle(themeColors);
      yield return this.GetListBoxItemStyle(themeColors);
      yield return this.GetMenuItemStyle(themeColors);
    }

    private static IThemeColors GetColors()
    {
      return new ThemeColors()
        .Text(new ColorPack()
          .Normal(Colors.White))
        .Control(new ColorPack()
          .Normal(Color.FromRgb(30,40,48))
          .Over(Color.FromRgb(75,83,88))
          .Selected(Color.FromRgb(169, 180, 193))
          .Accent1(Color.FromRgb(126, 187, 69))
          .Accent2(Color.FromRgb(233, 100, 68)))
        .Outline(new ColorPack()
          .Normal(Colors.Black));
    }
  }
}
