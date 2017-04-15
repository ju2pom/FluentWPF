using System.Windows.Media;

namespace FluentWPFAPI.ThemeApi.Color
{
  public interface IColorPack
  {
    Brush Normal { get; set; }

    Brush Over { get; set; }

    Brush Selected { get; set; }

    Brush Disabled { get; set; }

    Brush Accent1 { get; set; }

    Brush Accent2 { get; set; }
  }
}