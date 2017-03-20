namespace FluentWPFAPI
{
  public interface IFluentItem
  {
    void Initialize();
  }

  public interface IFluentItem<T> : IFluentItem
  {
    new T Initialize();
  }

  internal interface IInternalObjectItem : IFluentItem
  {
    object Element { get; }
  }

  internal interface IInternalFluentItem<T> : IInternalObjectItem
  {
    new T Element { get; }
  }
}