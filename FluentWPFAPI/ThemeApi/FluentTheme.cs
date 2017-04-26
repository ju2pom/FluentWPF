using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FluentWPFAPI.ThemeApi
{
  public abstract class FluentTheme : ResourceDictionary, IFluentTheme
  {
    private static List<IFluentTheme> themes = new List<IFluentTheme>();

    public static void Load(IFluentTheme theme, IThemeColors themeColors)
    {
      if (themes.Contains(theme))
      {
        return;
      }

      ResourceDictionary dictionary = (ResourceDictionary)theme;

      theme.GetDefaultStyles(themeColors)
        .Where(x => x != null)
        .ToList()
        .ForEach(x => dictionary.Add(x.TargetType, x));

      themes.Add(theme);
    }

    public static System.Windows.Style GetDefault<T>()
      where T : FrameworkElement
    {
      Type type = typeof(T);

      return themes
        .OfType<ResourceDictionary>()
        .Where(x => x.Contains(type))
        .Select(x => x[type])
        .SingleOrDefault() as System.Windows.Style;
    }

    public abstract IEnumerable<System.Windows.Style> GetDefaultStyles(IThemeColors themeColors);
  }
}