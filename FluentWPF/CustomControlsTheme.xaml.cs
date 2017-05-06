using System.Collections.Generic;
using System.Windows;
using FluentWPFAPI.ThemeApi;

namespace FluentWPF
{
  public partial class CustomControlsTheme
  {
    public CustomControlsTheme()
    {
      FluentTheme.Load(this, Theme.ThemeColors);
    }

    public override IEnumerable<Style> GetDefaultStyles(IThemeColors themeColors)
    {
      yield return GetDropDownButtonStyle(themeColors);
    }
  }
}
