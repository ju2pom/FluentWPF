using FluentWPFAPI.ThemeApi.Color;

namespace FluentWPFAPI.ThemeApi
{
  public interface IThemeColors
  {
    IColorPack Text { get; set; }

    IColorPack Control { get; set; }

    IColorPack Outline { get; set; }
  }
}
