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

    /// <summary>
    /// Add a new cell to the parent grid, you can specify row and columns using dedicated extension methods
    /// </summary>
    /// <example>
    /// <code>
    /// .Cell(GridCellExtensions.Create()
    ///   .Row(1).Column(2).Span(2, 1)
    ///   .Contains( ...))
    /// </code>
    /// </example>
    public static IFluentItem<Grid> Cell(this IFluentItem<Grid> fluentItem, IGridCell cell)
    {
      (fluentItem as GridFluentItem)?.SetupCell(cell);
      cell.HostInGrid(fluentItem.Element);
      fluentItem.AddChild(cell.Content);

      return fluentItem;
    }

    #region Rows

    public static IGridCell Row(this IFluentItem<Grid> item, GridLength height)
    {
      IGridCell cell = GridCellExtensions.Create();
      cell.Height = height;
      cell.Row = item.Element.RowDefinitions.Count;

      return cell;
    }

    public static IGridCell Row(this IFluentItem<Grid> grid, double height)
    {
      return grid.Row(new GridLength(height));
    }

    public static IGridCell Row(this IFluentItem<Grid> grid)
    {
      return grid.Row(GridLength.Auto);
    }

    public static IGridCell Row(this IFluentItem<Grid> grid, string pourcentage)
    {
      GridLength gridLength;
      if (GridCell.TryGetGridLength(pourcentage, out gridLength))
      {
        return grid.Row(gridLength);
      }

      throw new ArgumentException("{0} is not a valid grid height", pourcentage);
    }
    
    #endregion

    #region Columns

    public static IGridCell Column(this IFluentItem<Grid> item, GridLength width)
    {
      IGridCell cell = GridCellExtensions.Create();
      cell.Width = width;
      cell.Column = item.Element.ColumnDefinitions.Count;

      return cell;
    }

    public static IGridCell Column(this IFluentItem<Grid> grid, double width)
    {
      return grid.Column(new GridLength(width));
    }

    public static IGridCell Column(this IFluentItem<Grid> grid)
    {
      return grid.Column(GridLength.Auto);
    }

    public static IGridCell Column(this IFluentItem<Grid> grid, string pourcentage)
    {
      GridLength gridLength;
      if (GridCell.TryGetGridLength(pourcentage, out gridLength))
      {
        return grid.Column(gridLength);
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    #endregion

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