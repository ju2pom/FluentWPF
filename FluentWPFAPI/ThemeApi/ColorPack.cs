using System.Windows.Media;

namespace FluentWPFAPI.ThemeApi
{
  public class ColorPack : IColorPack
  {
    public ColorPack(Brush normal, Brush over, Brush selected, Brush disabled)
    {
      this.Normal = normal;
      this.Over = over;
      this.Selected = selected;
      this.Disabled = disabled;
    }

    public Brush Normal { get; }

    public Brush Over { get; }

    public Brush Selected { get; }

    public Brush Disabled { get; }

    public Brush Accent1 { get; set; }

    public Brush Accent2 { get; set; }
  }
}