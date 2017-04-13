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

    public FluentItem(T element)
    {
      bindings = new List<IFluentBinding>();
      children = new List<IFluentItem>();
      Element = element;
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

    void IFluentItem.Initialize(object dataContext)
    {
      this.Element.DataContext = dataContext;

      bindings
        .OfType<FluentBinding>()
        .ToList()
        .ForEach(x => x.Bind(this.Element, this.Element.DataContext));

      children.ForEach(x => x.Initialize(dataContext));
    }
  }
}