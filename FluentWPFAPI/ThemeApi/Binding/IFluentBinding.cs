﻿using System.Windows;
using System.Windows.Data;

namespace FluentWPFAPI.ThemeApi.Binding
{
  public interface IFluentBinding
  {
    object Source { get; set; }

    PropertyPath Path { get; set; }

    BindingMode Mode { get; set; }

    IValueConverter Converter { get; set; }

    void Bind(FrameworkElement element, object source);
  }
}