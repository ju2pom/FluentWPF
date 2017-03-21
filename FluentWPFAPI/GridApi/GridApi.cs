using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.GridApi
{
  public static class GridExtensions
  {
    public static IFluentItem DefaultCellSize(this IFluentItem item, double width, double height)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)item;
      GridFluentItem gridFluentItem = new GridFluentItem(fluentItem);

      gridFluentItem.DefaultWidth = new GridLength(width, GridUnitType.Pixel);
      gridFluentItem.DefaultHeight = new GridLength(height, GridUnitType.Pixel);

      return gridFluentItem;
    }

    public static IFluentItem DefaultCellSize(this IFluentItem item, string width, string height)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)item;
      GridFluentItem gridFluentItem = new GridFluentItem(fluentItem);

      GridLength gridLength;
      if (TryGetGridLength(width, out gridLength))
      {
        gridFluentItem.DefaultWidth = gridLength;
      }

      if (TryGetGridLength(height, out gridLength))
      {
        gridFluentItem.DefaultHeight = gridLength;
      }

      return gridFluentItem;
    }

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
      GridLength gridLength;
      if (TryGetGridLength(pourcentage, out gridLength))
      {
        FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
        fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = gridLength });

        return grid;
      }

      throw new ArgumentException("{0} is not a valid grid height", pourcentage);
    }

    public static IFluentItem Column(this IFluentItem grid, string pourcentage)
    {
      GridLength gridLength;
      if (TryGetGridLength(pourcentage, out gridLength))
      {
        FluentItem<Grid> fluentItem = (FluentItem<Grid>) grid;
        fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = gridLength });

        return grid;
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    public static IFluentItem Rows(this IFluentItem grid, params string[] pourcentages)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (string pourcentage in pourcentages)
      {
        GridLength gridLength;
        if (TryGetGridLength(pourcentage, out gridLength))
        {
          fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = gridLength });
        }
        else
        {
          throw new ArgumentException("{0} is not a valid grid height", pourcentage);
        }
      }

      return grid;
    }

    public static IFluentItem Columns(this IFluentItem grid, params string[] pourcentages)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (string pourcentage in pourcentages)
      {
        GridLength gridLength;
        if (TryGetGridLength(pourcentage, out gridLength))
        {
          fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = gridLength });
        }
        else
        {
          throw new ArgumentException("{0} is not a valid grid width", pourcentage);
        }
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

    public static IGridCell Width(this IGridCell cell, double width)
    {
      GridCell gridCell = (GridCell)cell;
      gridCell.Width = new GridLength(width, GridUnitType.Pixel);

      return cell;
    }

    public static IGridCell Width(this IGridCell cell, string pourcentage)
    {
      GridLength gridLength;
      if (TryGetGridLength(pourcentage, out gridLength))
      {
        GridCell gridCell = (GridCell)cell;
        gridCell.Width = gridLength;

        return cell;
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    public static IGridCell Height(this IGridCell cell, double width)
    {
      GridCell gridCell = (GridCell)cell;
      gridCell.Height = new GridLength(width, GridUnitType.Pixel);

      return cell;
    }

    public static IGridCell Height(this IGridCell cell, string pourcentage)
    {
      GridLength gridLength;
      if (TryGetGridLength(pourcentage, out gridLength))
      {
        GridCell gridCell = (GridCell)cell;
        gridCell.Height = gridLength;

        return cell;
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    public static IFluentItem Contains<T>(this IGridCell cell, IFluentItem<T> content)
      where T : FrameworkElement
    {
      GridCell gridCell = (GridCell)cell;
      FluentItem<Grid> fluentItem = (FluentItem<Grid>) gridCell.Grid;
      Grid grid = fluentItem.Element;
      fluentItem.AddChild(content);

      FluentItem<T> item = (FluentItem<T>) content;
      T element = item.Element;

      CreateRowAndColumnIfNeeded(fluentItem, gridCell);

      grid.Children.Add(element);
      Grid.SetRow(element, gridCell.Row);
      Grid.SetColumn(element, gridCell.Column);
      Grid.SetRowSpan(element, gridCell.RowSpan);
      Grid.SetColumnSpan(element, gridCell.ColSpan);

      return gridCell.Grid;
    }

    private static void CreateRowAndColumnIfNeeded(FluentItem<Grid> item, GridCell gridCell)
    {
      GridFluentItem gridFluentItem = item as GridFluentItem;
      GridLength defaultWidth = gridCell.Width ?? gridFluentItem?.DefaultWidth ?? new GridLength(0, GridUnitType.Auto);
      GridLength defaultHeight = gridCell.Height ?? gridFluentItem?.DefaultHeight ?? new GridLength(0, GridUnitType.Auto);

      Grid grid = item.Element;

      int columnsToAdd = gridCell.Column + gridCell.ColSpan - grid.ColumnDefinitions.Count;
      while (columnsToAdd > 0)
      {
        Column(item, defaultWidth);

        columnsToAdd--;
      }

      int rowsToAdd = gridCell.Row + gridCell.RowSpan - grid.RowDefinitions.Count;
      while (rowsToAdd > 0)
      {
        Row(item, defaultHeight);

        rowsToAdd--;
      }
    }

    private static bool TryGetGridLength(string value, out GridLength gridLength)
    {
      double size;
      if (double.TryParse(value, out size))
      {
        gridLength = new GridLength(size, GridUnitType.Star);

        return true;
      }
      else if (string.Compare(value, "auto", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        gridLength = new GridLength(0, GridUnitType.Auto);

        return true;
      }

      gridLength = default(GridLength);

      return false;
    }

    private class GridFluentItem : FluentItem<Grid>
    {
      private readonly FluentItem<Grid> _fluentItem;

      public GridFluentItem(FluentItem<Grid> fluentItem) : base(fluentItem.Element)
      {
        _fluentItem = fluentItem;
      }

      public GridLength DefaultWidth { get; set; }

      public GridLength DefaultHeight { get; set; }
    }
  }
}