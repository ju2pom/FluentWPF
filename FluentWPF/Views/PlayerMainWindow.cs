using System.Windows;
using System.Windows.Controls;
using FluentWPF.ViewModel;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.HeaderedContentControlApi;
using FluentWPFAPI.TabControlApi;
using FluentWPFAPI.ThemeApi.Binding;
using FluentWPFAPI.WindowApi;

namespace FluentWPF.Views
{
  public class PlayerMainWindow : Window
  {
    public PlayerMainWindow()
    {
      this.AsFluent<Window>()
        .DataContext(new RootViewModel())
        .NoBorder()
        .NoResize()
        .Set(Control.MaxHeightProperty, 420d)
        .SizeToContent(SizeToContent.WidthAndHeight)
        .Transparent()
        .Contains(new Grid()
            .AsFluent()
            .Cell(GridCellExtensions.Create()
              .AutoHeight()
              .Contains(new Expander()
                .AsFluent<HeaderedContentControl>()
                .Top()
                .Size(400, 400)
                .Bind(BindingExtensions
                  .TwoWay(Expander.IsExpandedProperty)
                  .With(nameof(RootViewModel.IsMenuOpened)))
                .Set(Panel.ZIndexProperty, 1)
                .UseStyle(Theme.HambergerMenu)
                .Header("Titre")
                .Contains(new MainMenuView().AsFluent())))
          .Cell(GridCellExtensions.Create()
            .Height("*")
            .Contains(new TabControl()
              .AsFluent()
              .Bind(BindingExtensions
                .TwoWay(TabControl.SelectedIndexProperty)
                .With(nameof(RootViewModel.CurrentView)))
              .Tab(new PlayerView().AsFluent())
              .Tab(new SearchView().AsFluent())
            )))
        .Initialize(null);
    }
  }
}
