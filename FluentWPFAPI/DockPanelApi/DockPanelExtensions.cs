using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.DockPanelApi
{
  public static class DockPanelExtensions
  {
    public static IFluentItem<DockPanel> DockLeft<T>(this IFluentItem<DockPanel> dockPanel, IFluentItem<T> child)
      where T : FrameworkElement
    {
      Dock(dockPanel, child, System.Windows.Controls.Dock.Left);

      return dockPanel;
    }

    public static IFluentItem<DockPanel> DockRight<T>(this IFluentItem<DockPanel> dockPanel, IFluentItem<T> child)
      where T : FrameworkElement
    {
      Dock(dockPanel, child, System.Windows.Controls.Dock.Right);

      return dockPanel;
    }

    //public static IFluentItem<DockPanel> DockTop(this IFluentItem<DockPanel> dockPanel, IFluentItem child)
    public static IFluentItem<DockPanel> DockTop<T>(this IFluentItem<DockPanel> dockPanel, IFluentItem<T> child)
      where T : FrameworkElement
    {
      Dock(dockPanel, child, System.Windows.Controls.Dock.Top);

      return dockPanel;
    }

    public static IFluentItem<DockPanel> DockBottom<T>(this IFluentItem<DockPanel> dockPanel, IFluentItem<T> child)
      where T : FrameworkElement
    {
      Dock(dockPanel, child, System.Windows.Controls.Dock.Bottom);

      return dockPanel;
    }

    public static IFluentItem<DockPanel> Dock<T>(this IFluentItem<DockPanel> dockPanel, IFluentItem<T> child)
      where T : FrameworkElement
    {
      Dock(dockPanel, child, null);

      return dockPanel;
    }

    public static IFluentItem<DockPanel> LastChildFill<T>(this IFluentItem<DockPanel> dockPanel, bool lastChildFill)
      where T : FrameworkElement
    {
      ((FluentItem<DockPanel>) dockPanel).Element.LastChildFill = lastChildFill;
      return dockPanel;
    }

    //private static void Dock(IFluentItem<DockPanel> dockPanel, IFluentItem child, Dock dock)
    private static void Dock<T>(IFluentItem<DockPanel> dockPanel, IFluentItem<T> child, Dock? dock)
      where T : FrameworkElement
    {
      FluentItem<DockPanel> item = (FluentItem<DockPanel>)dockPanel;
      T childItem = ((FluentItem<T>)child).Element;

      if (dock.HasValue)
      {
        DockPanel.SetDock(childItem, dock.Value);
      }

      item.Element.Children.Add(childItem);
    }
  }
}
