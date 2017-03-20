using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FluentWPFAPI
{
  internal class FluentItem<T> : IInternalFluentItem<T>, IFluentItem<T>
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

    object IInternalObjectItem.Element
    {
      get { return Element; }
    }

    public T Initialize()
    {
      (this as IFluentItem).Initialize();

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

    void IFluentItem.Initialize()
    {
      bindings
        .OfType<FluentBinding>()
        .ToList()
        .ForEach(x => x.Apply());

      children.ForEach(x => x.Initialize());
    }
  }
}