namespace FluentWPFAPI.ThemeApi
{
  public interface IThemeColors
  {
    IColorPack Text { get; }

    IColorPack Control { get; }

    IColorPack Outline { get; }
  }
}
