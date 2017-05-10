using System.Collections.Generic;
using System.Windows.Controls;

namespace FluentWPF.Views
{
  public static class SearchContextMenuBuilder
  {
    public static ContextMenu Create()
    {
      return new ContextMenu
      {
        ItemsSource = new List<MenuItem>
        {
          new MenuItem {Header = "Search for artist"},
          new MenuItem {Header = "Search for album"},
          new MenuItem {Header = "Search for song"},
        }
      };
    }
  }
}
