using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using FluentWPF.ViewModel;
using FluentWPFAPI;
using FluentWPFAPI.ContentControlApi;
using FluentWPFAPI.FrameworkElementApi;
using FluentWPFAPI.GridApi;
using FluentWPFAPI.ThemeApi.Binding;

namespace FluentWPF.Views
{
  public class MainMenuView : Grid
  {
    private readonly IFluentItem<Grid> fluentItem;

    public MainMenuView()
    {
      this.fluentItem = this
        .AsFluent<Grid>()
        .Set(Control.BackgroundProperty, Theme.ThemeColors.Control.Normal)
        .Set(StackPanel.OrientationProperty, Orientation.Horizontal)
        .Set(Control.FontFamilyProperty, new FontFamily("SEGOE MDL2 assets"))
        .Set(Control.FontSizeProperty, 18d)
        .Set(FrameworkElement.HeightProperty, 80d)
        .DefaultCellSize("*", "*")
        .Cell(GridCellExtensions.Create()
          .Contains(new Button()
            .AsFluent()
            .Contains("\xE90B")
            .Bind(BindingExtensions
              .OneTime(ButtonBase.CommandProperty)
              .With(nameof(RootViewModel.OpenSearchViewCommand)))))
        .Cell(GridCellExtensions.Create()
          .Column(1)
          .Contains(new Button()
            .AsFluent()
            .Contains("\xE8D6")
            .Bind(BindingExtensions
              .OneTime(ButtonBase.CommandProperty)
              .With(nameof(RootViewModel.OpenPlayerViewCommand)))))
        .Cell(GridCellExtensions.Create()
          .Column(2)
          .Contains(new Button()
            .AsFluent()
            .Contains("\xE74F")));
    }

    public IFluentItem<Grid> AsFluent()
    {
      return this.fluentItem;
    }
  }
}
