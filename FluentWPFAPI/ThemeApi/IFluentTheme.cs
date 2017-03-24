namespace FluentWPFAPI.ThemeApi
{
  public interface IFluentTheme
  {
    void LoadButtonStyle(IThemeColors colors);

    void LoadCheckBoxStyle(IThemeColors colors);

    void LoadRadioButtonStyle(IThemeColors colors);

    void LoadCustomStyles(IThemeColors colors);
  }
}
