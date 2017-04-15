using FluentWPFAPI.ThemeApi.Color;

namespace FluentWPFAPI.ThemeApi
{
  public class ThemeColors : IThemeColors
  {
    public ThemeColors() { }

    public ThemeColors(IColorPack text, IColorPack control, IColorPack outline)
    {
      this.Text = text;
      this.Control = control;
      this.Outline = outline;
    }

    public IColorPack Text { get; set; }

    public IColorPack Control { get; set; }

    public IColorPack Outline { get; set; }
  }
}