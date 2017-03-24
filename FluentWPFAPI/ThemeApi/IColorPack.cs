using System.Windows.Media;

namespace FluentWPFAPI.ThemeApi
{
  public interface IColorPack
  {
    Brush Normal { get; }

    Brush Over { get; }

    Brush Selected { get; }

    Brush Disabled { get; }

    Brush Accent1 { get; }

    Brush Accent2 { get; }
  }
}