using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentWPF.CustomControls
{
  public class DropDownButton : Button
  {
    static DropDownButton()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
    }

    protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
    {
      if (this.ContextMenu != null)
      {
        this.ContextMenu.IsOpen = true;
      }

      e.Handled = true;
    }

    protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
    {
      e.Handled = true;
    }
  }
}
