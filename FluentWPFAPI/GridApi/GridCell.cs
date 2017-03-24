using System.Windows;

namespace FluentWPFAPI.GridApi
{
  internal class GridCell : IGridCell
  {
    public GridCell(IFluentItem grid, int row, int column)
    {
      Grid = grid;
      Row = row;
      Column = column;
      RowSpan = 1;
      ColSpan = 1;
    }

    internal IFluentItem Grid { get; }

    internal int Row { get; }

    internal int Column { get; }

    internal int RowSpan { get; set; }

    internal int ColSpan { get; set; }

    internal GridLength? Width { get; set; }

    internal GridLength? Height { get; set; }

    /*    public static implicit operator Grid(GridCell gridCell)
        {
          if (gridCell.Element == null)
            throw new InvalidOperationException(
              $"You should setup the content of this cell before ({gridCell.Row}, {gridCell.Column})");

          return gridCell.Grid;
        }*/
  }
}