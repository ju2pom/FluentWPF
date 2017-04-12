using System.Windows;

namespace FluentWPFAPI.GridApi
{
  public interface IGridCell
  {
    int Row { get; set; }

    int Column { get; set; }

    int RowSpan { get; set; }

    int ColSpan { get; set; }

    GridLength? Width { get; set; }

    GridLength? Height { get; set; }

    IFluentItem Content { get; set; }
  }
}