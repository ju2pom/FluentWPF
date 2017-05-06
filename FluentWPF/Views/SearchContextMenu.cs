using System.Collections.Generic;
using System.Windows.Controls;
using FluentWPFAPI.FrameworkElementApi;

namespace FluentWPF.Views
{
  public class SearchContextMenu : ContextMenu
  {
    public SearchContextMenu()
    {
      List<MenuItem> menuItems = new List<MenuItem>
      {
        new MenuItem {Header = "Search for artist"},
        new MenuItem {Header = "Search for song"},
      };

      this.AsFluent()
        .Set(ItemsControl.ItemsSourceProperty, menuItems);
    }
  }
}
