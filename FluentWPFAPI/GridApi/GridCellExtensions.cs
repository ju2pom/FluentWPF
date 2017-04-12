using System;
using System.Windows;

namespace FluentWPFAPI.GridApi
{
  public static class GridCellExtensions
  {
    public static IGridCell Create()
    {
      return new GridCell();
    }

    public static IGridCell Row(this IGridCell cell, int row)
    {
      cell.Row = row;

      return cell;
    }

    public static IGridCell Column(this IGridCell cell, int col)
    {
      cell.Column = col;

      return cell;
    }

    public static IGridCell Span(this IGridCell cell, int rowSpan, int colSpan)
    {
      cell.RowSpan = rowSpan;
      cell.ColSpan = colSpan;

      return cell;
    }

    public static IGridCell Width(this IGridCell cell, double width)
    {
      cell.Width = new GridLength(width, GridUnitType.Pixel);

      return cell;
    }

    public static IGridCell Width(this IGridCell cell, string pourcentage)
    {
      GridLength gridLength;
      if (GridCell.TryGetGridLength(pourcentage, out gridLength))
      {
        cell.Width = gridLength;

        return cell;
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    public static IGridCell AutoWidth(this IGridCell cell)
    {
      cell.Width = GridLength.Auto;

      return cell;
    }

    public static IGridCell Height(this IGridCell cell, double width)
    {
      cell.Height = new GridLength(width, GridUnitType.Pixel);

      return cell;
    }

    public static IGridCell Height(this IGridCell cell, string pourcentage)
    {
      GridLength gridLength;
      if (GridCell.TryGetGridLength(pourcentage, out gridLength))
      {
        cell.Height = gridLength;

        return cell;
      }

      throw new ArgumentException("{0} is not a valid grid width", pourcentage);
    }

    public static IGridCell AutoHeight(this IGridCell cell)
    {
      cell.Height = GridLength.Auto;

      return cell;
    }

    public static IGridCell Contains(this IGridCell cell, IFluentItem content)
    {
      cell.Content = content;

      return cell;
    }
  }
}
