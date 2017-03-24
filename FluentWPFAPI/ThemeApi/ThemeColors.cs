namespace FluentWPFAPI.ThemeApi
{
  public class ThemeColors : IThemeColors
  {
    public ThemeColors(IColorPack text, IColorPack control, IColorPack outline)
    {
      this.Text = text;
      this.Control = control;
      this.Outline = outline;
    }

    public IColorPack Text { get; }

    public IColorPack Control { get; }

    public IColorPack Outline { get; }
  }
}