using System.Windows;

namespace FluentWPFAPI.ThemeApi
{
  public interface IFluentTheme
  {
    void LoadButtonStyle();

    void LoadCheckBoxStyle();

    void LoadRadioButtonStyle();

    void LoadCustomStyles();
  }

  public class FluentTheme : ResourceDictionary, IFluentTheme
  {
    public FluentTheme()
    {
      this.LoadButtonStyle();
      this.LoadCheckBoxStyle();
      this.LoadRadioButtonStyle();

      this.LoadCustomStyles();
    }

    public virtual void LoadButtonStyle() { }

    public virtual void LoadCheckBoxStyle() { }

    public virtual void LoadRadioButtonStyle() { }

    public virtual void LoadCustomStyles() { }
  }
}
