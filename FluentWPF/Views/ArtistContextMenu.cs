using System.Collections.Generic;
using System.Windows.Controls;
using FluentWPFAPI.FrameworkElementApi;

namespace FluentWPF.Views
{
  public class ArtistContextMenu : ContextMenu
  {
    public ArtistContextMenu()
    {
      List<MenuItem> menuItems = new List<MenuItem>
      {
        new MenuItem {Header = "Show Artist"},
        new MenuItem {Header = "Star Artist"},
      };

      this.AsFluent()
        .Set(ItemsControl.ItemsSourceProperty, menuItems);
    }
  }
}
