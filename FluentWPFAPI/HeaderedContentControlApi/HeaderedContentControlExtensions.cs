using System.Windows.Controls;

namespace FluentWPFAPI.HeaderedContentControlApi
{
  public static class HeaderedContentControlExtensions
  {
    public static IFluentItem<HeaderedContentControl> Header(this IFluentItem<HeaderedContentControl> fluentItem, IFluentItem header)
    {
      fluentItem.Element.Header = header.Element;
      fluentItem.AddChild(header);
      
      return fluentItem; 
    }

    public static IFluentItem<HeaderedContentControl> Header(this IFluentItem<HeaderedContentControl> fluentItem, string header)
    {
      fluentItem.Element.Header = header;

      return fluentItem;
    }
  }
}
