using System.Windows.Media;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Color;

namespace FluentWPF
{
  public partial class Theme : FluentTheme
  {
    private static readonly IThemeColors colors;

    static Theme()
    {
      colors = new ThemeColors()
        .Text(new ColorPack()
          .Normal(Colors.Black))
        .Control(new ColorPack()
          .Normal(Colors.DarkGray)
          .Over(Colors.LightGray))
        .Outline(new ColorPack()
          .Normal(Colors.Black));
    }

    public Theme()
      : base(colors)
    {
      this.InitializeComponent();
    }
  }
}
