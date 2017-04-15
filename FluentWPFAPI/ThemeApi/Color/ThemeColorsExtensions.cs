namespace FluentWPFAPI.ThemeApi.Color
{
  public static class ThemeColorsExtensions
  {
    public static IThemeColors Text(this IThemeColors themeColors, IColorPack colorPack)
    {
      themeColors.Text = colorPack;

      return themeColors;
    }

    public static IThemeColors Control(this IThemeColors themeColors, IColorPack colorPack)
    {
      themeColors.Control = colorPack;

      return themeColors;
    }

    public static IThemeColors Outline(this IThemeColors themeColors, IColorPack colorPack)
    {
      themeColors.Outline = colorPack;

      return themeColors;
    }
  }
}
