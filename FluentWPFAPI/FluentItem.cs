using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FluentWPFAPI.ThemeApi.Binding;

namespace FluentWPFAPI
{
  internal class FluentItem<T> : IFluentItem<T>
    where T : FrameworkElement
  {
    private readonly List<IFluentBinding> bindings;
    private readonly List<IFluentItem> children;
    private readonly List<Tuple<RoutedEvent, RoutedEventHandler>> eventHandlers;

    public FluentItem(T element)
    {
      this.bindings = new List<IFluentBinding>();
      this.children = new List<IFluentItem>();
      this.eventHandlers = new List<Tuple<RoutedEvent, RoutedEventHandler>>();
      this.Element = element;
    }

    public T Element { get; }

    FrameworkElement IFluentItem.Element => Element;

    public T Initialize(object dataContext)
    {
      (this as IFluentItem).Initialize(this.Element.DataContext ?? dataContext);

      return this.Element;
    }

    public void AddBinding(IFluentBinding binding)
    {
      bindings.Add(binding);
    }

    public void AddChild(IFluentItem child)
    {
      children.Add(child);
    }

    public void AddHandler(RoutedEvent ev, RoutedEventHandler handler)
    {
      this.eventHandlers.Add(new Tuple<RoutedEvent, RoutedEventHandler>(ev, handler));
    }

    void IFluentItem.Initialize(object dataContext)
    {
      this.bindings
        .OfType<FluentBinding>()
        .ToList()
        .ForEach(x => x.Bind(this.Element, this.Element.DataContext));

      this.eventHandlers
        .ForEach(x => this.Element.AddHandler(x.Item1, x.Item2));

      this.children.ForEach(x => x.Initialize(dataContext));
    }
  }
}