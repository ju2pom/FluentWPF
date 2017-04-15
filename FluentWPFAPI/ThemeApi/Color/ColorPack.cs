using System.Windows.Media;

namespace FluentWPFAPI.ThemeApi.Color
{
  public class ColorPack : IColorPack
  {
    public ColorPack() { }

    public ColorPack(Brush normal, Brush over = null, Brush selected = null, Brush disabled = null)
    {
      this.Normal = normal;
      this.Over = over ?? normal;
      this.Selected = selected ?? normal;
      this.Disabled = disabled ?? normal;
    }

    public Brush Normal { get; set; }

    public Brush Over { get; set; }

    public Brush Selected { get; set; }

    public Brush Disabled { get; set; }

    public Brush Accent1 { get; set; }

    public Brush Accent2 { get; set; }
  }
}