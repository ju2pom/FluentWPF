using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FluentWPFAPI.ThemeApi
{
  public abstract class FluentTheme : ResourceDictionary, IFluentTheme
  {
    public static void Load(IFluentTheme theme, IThemeColors themeColors)
    {
      ResourceDictionary dictionary = (ResourceDictionary)theme;

      theme.GetDefaultStyles(themeColors)
        .ToList()
        .ForEach(x => dictionary.Add(x.TargetType, x));
    }

    public abstract IEnumerable<System.Windows.Style> GetDefaultStyles(IThemeColors themeColors);
  }
}