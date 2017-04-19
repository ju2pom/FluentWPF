using System;
using System.Windows;
using System.Windows.Controls;
using FluentWPFAPI.ThemeApi.Style;
using FluentWPFAPI.ThemeApi.Template;

namespace FluentWPFAPI.ItemsControlApi
{
  public static class ItemsControlExtensions
  {
    public static IFluentStyle PanelTemplate(this IFluentStyle fluentStyle, IFluentTemplateItem template)
    {
      var fluentTemplateItem = template as FluentTemplateItem;
      FrameworkElementFactory factory = fluentTemplateItem.GetFactory();
     
      factory.SetValue(Panel.IsItemsHostProperty, true);
      fluentStyle.Set(ItemsControl.ItemsPanelProperty, new ItemsPanelTemplate {VisualTree = factory});

      return fluentStyle;
    }
  }
}
