using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.GridApi
{
  public static class GridExtensions
  {
    public static IFluentItem Row(this IFluentItem item, GridLength height)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)item;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = height });

      return item;
    }

    public static IFluentItem Column(this IFluentItem item, GridLength width)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)item;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

      return item;
    }

    public static IFluentItem Row(this IFluentItem grid, double height)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = new GridLength(height) });

      return grid;
    }

    public static IFluentItem Column(this IFluentItem grid, double width)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width) });

      return grid;
    }

    public static IFluentItem Row(this IFluentItem grid)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

      return grid;
    }

    public static IFluentItem Column(this IFluentItem grid)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

      return grid;
    }

    public static IFluentItem Row(this IFluentItem grid, string pourcentage)
    {
      double height;
      double.TryParse(pourcentage, out height);

      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = new GridLength(height, GridUnitType.Star) });

      return grid;
    }

    public static IFluentItem Column(this IFluentItem grid, string pourcentage)
    {
      double width;
      double.TryParse(pourcentage, out width);

      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width, GridUnitType.Star) });

      return grid;
    }

    public static IFluentItem Rows(this IFluentItem grid, params string[] pourcentages)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (string pourcentage in pourcentages)
      {
        double height;
        if (double.TryParse(pourcentage, out height))
        {
          fluentItem.Element.RowDefinitions.Add(new RowDefinition {Height = new GridLength(height, GridUnitType.Star)});
        }
        else if (string.Compare(pourcentage, "auto", StringComparison.InvariantCultureIgnoreCase) == 0)
        {
          fluentItem.Element.RowDefinitions.Add(new RowDefinition {Height = new GridLength(0, GridUnitType.Auto)});
        }
      }

      return grid;
    }

    public static IFluentItem Columns(this IFluentItem grid, params string[] pourcentages)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (string pourcentage in pourcentages)
      {
        double width;
        double.TryParse(pourcentage, out width);

        fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(width, GridUnitType.Star)});
      }

      return grid;
    }

    public static IFluentItem Rows(this IFluentItem grid, params int[] pixels)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (int height in pixels)
      {
        fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = new GridLength(height, GridUnitType.Star) });
      }

      return grid;
    }

    public static IFluentItem Columns(this IFluentItem grid, params int[] pixels)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (int width in pixels)
      {
        fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width, GridUnitType.Star) });
      }

      return grid;
    }

    public static IGridCell Cell(this IFluentItem grid, int row, int column)
    {
      return new GridCell(grid, row, column);
    }

    public static IGridCell Span(this IGridCell cell, int rowSpan, int colSpan)
    {
      GridCell gridCell = (GridCell)cell;
      gridCell.RowSpan = rowSpan;
      gridCell.ColSpan = colSpan;

      return cell;
    }

    public static IFluentItem Set<T>(this IGridCell cell, IFluentItem<T> content)
      where T : FrameworkElement
    {
      GridCell gridCell = (GridCell)cell;
      FluentItem<Grid> fluentItem = (FluentItem<Grid>) gridCell.Grid;
      Grid grid = fluentItem.Element;
      fluentItem.AddChild(content);

      FluentItem<T> item = (FluentItem<T>) content;
      T element = item.Element;

      grid.Children.Add(element);
      Grid.SetRow(element, gridCell.Row);
      Grid.SetColumn(element, gridCell.Column);
      Grid.SetRowSpan(element, gridCell.RowSpan);
      Grid.SetColumnSpan(element, gridCell.ColSpan);

      return gridCell.Grid;
    }
  }
}