namespace FluentWPFAPI.ThemeApi.Template
{
  public interface IFluentTemplateItemWithChild : IFluentTemplateItem
  {
    void Add(IFluentTemplateItem item);
  }
}