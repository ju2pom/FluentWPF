using System;
using System.Windows;
using System.Windows.Controls;

namespace FluentWPFAPI.GridApi
{
  internal class GridCell : IGridCell
  {
    public GridCell()
    {
      RowSpan = 1;
      ColSpan = 1;
    }

    public int Row { get; set; }

    public int Column { get; set; }

    public int RowSpan { get; set; }

    public int ColSpan { get; set; }

    public GridLength? Width { get; set; }

    public GridLength? Height { get; set; }

    public IFluentItem Content { get; set; }

    public void HostInGrid(Grid grid)
    {
      this.CreateRowAndColumnIfNeeded(grid);
      FrameworkElement element = this.Content.Element;

      grid.Children.Add(element);
      Grid.SetRow(element, this.Row);
      Grid.SetColumn(element, this.Column);
      Grid.SetRowSpan(element, this.RowSpan);
      Grid.SetColumnSpan(element, this.ColSpan);
    }

    internal static bool TryGetGridLength(string value, out GridLength gridLength)
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
      else if (string.Compare(value, "*", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        gridLength = new GridLength(1, GridUnitType.Star);

        return true;
      }

      gridLength = default(GridLength);

      return false;
    }

    private void CreateRowAndColumnIfNeeded(Grid grid)
    {
      GridLength defaultWidth = this.Width ?? new GridLength(0, GridUnitType.Auto);
      GridLength defaultHeight = this.Height ?? new GridLength(0, GridUnitType.Auto);

      int columnsToAdd = this.Column + this.ColSpan - grid.ColumnDefinitions.Count;
      while (columnsToAdd > 0)
      {
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = defaultWidth });
        columnsToAdd--;
      }

      int rowsToAdd = this.Row + this.RowSpan - grid.RowDefinitions.Count;
      while (rowsToAdd > 0)
      {
        grid.RowDefinitions.Add(new RowDefinition { Height = defaultHeight });
        rowsToAdd--;
      }
    }
  }
}