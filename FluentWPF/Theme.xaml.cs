using FluentWPFAPI.ThemeApi;

namespace FluentWPF
{
  public partial class Theme : FluentTheme
  {
    private static IThemeColors colors;

    static Theme()
    {
      
    }

    public Theme()
      : base(colors)
    {
      this.InitializeComponent();
    }
  }
}
