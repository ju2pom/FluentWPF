using System.Windows.Media;

namespace FluentWPFAPI.ThemeApi
{
  public class ColorPack : IColorPack
  {
    public ColorPack(Brush normal, Brush over = null, Brush selected = null, Brush disabled = null)
    {
      this.Normal = normal;
      this.Over = over ?? normal;
      this.Selected = selected ?? normal;
      this.Disabled = disabled ?? normal;
    }

    public Brush Normal { get; }

    public Brush Over { get; }

    public Brush Selected { get; }

    public Brush Disabled { get; }

    public Brush Accent1 { get; set; }

    public Brush Accent2 { get; set; }
  }
}