using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FluentWPFAPI.ContentControlApi;

namespace FluentWPFAPI.ImageApi
{
  public static class ImageExtensions
  {
    public static IFluentItem<Image> Image()
    {
      return new Image().AsFluent();
    }

    public static IFluentItem<Image> From(this IFluentItem<Image> item, string source)
    {
      string packedUri = $"pack://application:,,,/{Assembly.GetCallingAssembly().GetName()};component/{source}";

      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.UriSource = new Uri(packedUri);
      bitmapImage.EndInit();

      FluentItem<Image> fluentItem = (FluentItem<Image>)item;
      fluentItem.Element.Source = bitmapImage;

      return item;
    }

    public static IFluentItem<Image> Stretch(this IFluentItem<Image> item, Stretch stretch)
    {
      FluentItem<Image> fluentItem = (FluentItem<Image>)item;
      fluentItem.Element.Stretch = stretch;

      return item;
    }
  }
}