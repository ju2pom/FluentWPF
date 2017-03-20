using System.Windows;

namespace FluentWPF
{
  public partial class Theme
  {
    private static Theme _instance;

    public static Theme Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new Theme();
        }

        return _instance;
      }
    }

    public Theme()
    {
      this.InitializeComponent();
    }

    public static Style NiceCheckBox => Instance[nameof(Theme.NiceCheckBox)] as Style;
  }
}
