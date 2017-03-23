using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPFAPI.ThemeApi;

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

      this.LoadCheckBox();
    }

    public static Style NiceCheckBox => Instance[nameof(Theme.NiceCheckBox)] as Style;
  }

  public partial class Theme
  {
    protected void LoadCheckBox()
    {
      var template = TemplateExtensions.Template<CheckBox>()
          .Factory<CheckBox, Border>()
          .Bind(Control.BackgroundProperty, Control.BackgroundProperty)
          .Factory<CheckBox, ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .Bind(ContentPresenter.ContentProperty, ContentControl.ContentProperty)
          .Get()
        ;

      this.CheckBox = StyleExtensions.Style<CheckBox>()
        .When(ToggleButton.IsCheckedProperty)
        .Is(true)
        .Then(Control.FontWeightProperty, FontWeights.Bold)
        .Then(Control.ForegroundProperty, new SolidColorBrush(Colors.DarkBlue))
        .EndWhen()
        .When(UIElement.IsMouseOverProperty)
        .Is(true)
        .Then(Control.BackgroundProperty, new SolidColorBrush(Colors.Bisque))
        .EndWhen()
        .Template(template)
        .Get();

    }

    public Style CheckBox { get; private set; }
  }
}
