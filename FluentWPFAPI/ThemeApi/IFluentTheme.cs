using System.Collections;
using System.Collections.Generic;

namespace FluentWPFAPI.ThemeApi
{
  public interface IFluentTheme
  {
    IEnumerable<System.Windows.Style> GetDefaultStyles(IThemeColors colors);
  }
}
