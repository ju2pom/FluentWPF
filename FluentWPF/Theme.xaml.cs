using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;
using FluentWPFAPI.ThemeApi.Color;

namespace FluentWPF
{
  public partial class Theme : FluentTheme
  {
    public Theme()
    {
      this.InitializeComponent();

      FluentTheme.Load(this, this.GetColors());
    }

    public override IEnumerable<Style> GetDefaultStyles(IThemeColors themeColors)
    {
      yield return this.GetWindowStyle(themeColors);
      yield return this.GetButtonStyle(themeColors);
      yield return this.GetCheckBoxStyle(themeColors);
    }

    private IThemeColors GetColors()
    {
      return new ThemeColors()
        .Text(new ColorPack()
          .Normal(Colors.Black))
        .Control(new ColorPack()
          .Normal(Colors.DarkGray)
          .Over(Colors.LightGray))
        .Outline(new ColorPack()
          .Normal(Colors.Black));
    }
  }
}
