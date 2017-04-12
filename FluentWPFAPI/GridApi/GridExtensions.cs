using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.GridApi
{
  public static class GridExtensions
  {
    public static IFluentItem<Grid> DefaultCellSize(this IFluentItem<Grid> item, double width, double height)
    {
      GridFluentItem gridFluentItem = new GridFluentItem(item);

      gridFluentItem.DefaultWidth = new GridLength(width, GridUnitType.Pixel);
      gridFluentItem.DefaultHeight = new GridLength(height, GridUnitType.Pixel);

      return gridFluentItem;
    }

    public static IFluentItem<Grid> DefaultCellSize(this IFluentItem<Grid> item, string width, string height)
    {
      GridFluentItem gridFluentItem = new GridFluentItem(item);

      GridLength gridLength;
      if (GridCell.TryGetGridLength(width, out gridLength))
      {
        gridFluentItem.DefaultWidth = gridLength;
      }

      if (GridCell.TryGetGridLength(height, out gridLength))
      {
        gridFluentItem.DefaultHeight = gridLength;
      }

      return gridFluentItem;
    }

    public static IFluentItem<Grid> Row(this IFluentItem<Grid> item, GridLength height)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)item;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = height });

      return item;
    }

    public static IFluentItem<Grid> Column(this IFluentItem<Grid> item, GridLength width)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)item;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

      return item;
    }

    public static IFluentItem<Grid> Row(this IFluentItem<Grid> grid, double height)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = new GridLength(height) });

      return grid;
    }

    public static IFluentItem<Grid> Column(this IFluentItem<Grid> grid, double width)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width) });

      return grid;
    }

    public static IFluentItem<Grid> Row(this IFluentItem<Grid> grid)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

      return grid;
    }

    public static IFluentItem<Grid> Column(this IFluentItem<Grid> grid)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
      fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

      return grid;
    }

    public static IFluentItem<Grid> Row(this IFluentItem<Grid> grid, string pourcentage)
    {
      GridLength gridLength;
      if (GridCell.TryGetGridLength(pourcentage, out gridLength))
      {
        FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;
        fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = gridLength });

        return grid;
      }

      throw new ArgumentException("{0} is not a valid grid height", pourcentage);
    }

    public static IFluentItem<Grid> Column(this IFluentItem<Grid> grid, string pourcentage)
    {
      GridLength gridLength;
      if (GridCell.TryGetGridLength(pourcentage, out gridLength))
      {
        FluentItem<Grid> fluentItem = (FluentItem<Grid>) grid;
        fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = gridLength });

        return grid;
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    public static IFluentItem<Grid> Rows(this IFluentItem<Grid> grid, params string[] pourcentages)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (string pourcentage in pourcentages)
      {
        GridLength gridLength;
        if (GridCell.TryGetGridLength(pourcentage, out gridLength))
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

    public static IFluentItem<Grid> Columns(this IFluentItem<Grid> grid, params string[] pourcentages)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (string pourcentage in pourcentages)
      {
        GridLength gridLength;
        if (GridCell.TryGetGridLength(pourcentage, out gridLength))
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

    public static IFluentItem<Grid> Rows(this IFluentItem<Grid> grid, params int[] pixels)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (int height in pixels)
      {
        fluentItem.Element.RowDefinitions.Add(new RowDefinition { Height = new GridLength(height, GridUnitType.Star) });
      }

      return grid;
    }

    public static IFluentItem<Grid> Columns(this IFluentItem<Grid> grid, params int[] pixels)
    {
      FluentItem<Grid> fluentItem = (FluentItem<Grid>)grid;

      foreach (int width in pixels)
      {
        fluentItem.Element.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width, GridUnitType.Star) });
      }

      return grid;
    }


    public static IFluentItem<Grid> Cell(this IFluentItem<Grid> fluentItem, IGridCell cell)
    {
      GridFluentItem item = (GridFluentItem)fluentItem;
      GridCell gridCell = (GridCell) cell;

      item.SetupCell(cell);
      gridCell.Insert(item.Element);

      return fluentItem;
    }

    private class GridFluentItem : FluentItem<Grid>
    {
      private readonly IFluentItem<Grid> _fluentItem;

      public GridFluentItem(IFluentItem<Grid> fluentItem) : base(fluentItem.Element)
      {
        _fluentItem = fluentItem;
      }

      public GridLength DefaultWidth { get; set; }

      public GridLength DefaultHeight { get; set; }

      public void SetupCell(IGridCell cell)
      {
        if (!cell.Width.HasValue)
        {
          cell.Width = this.DefaultWidth;
        }

        if (!cell.Height.HasValue)
        {
          cell.Height = this.DefaultHeight;
        }
      }
    }
  }
}