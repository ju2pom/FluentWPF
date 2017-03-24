using System.Windows;

namespace FluentWPFAPI.ThemeApi
{
  public class FluentTheme : ResourceDictionary, IFluentTheme
  {
    public FluentTheme(IThemeColors colors)
    {
      this.LoadButtonStyle(colors);
      this.LoadCheckBoxStyle(colors);
      this.LoadRadioButtonStyle(colors);

      this.LoadCustomStyles(colors);
    }

    public virtual void LoadButtonStyle(IThemeColors colors) { }

    public virtual void LoadCheckBoxStyle(IThemeColors colors) { }

    public virtual void LoadRadioButtonStyle(IThemeColors colors) { }

    public virtual void LoadCustomStyles(IThemeColors colors) { }
  }
}