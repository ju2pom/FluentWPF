FluentWPF

The goal of this library is to replace Xaml with C# to describe UI.

# Why?
- Reduce verbosity
- Provide more flexibility
- Improve reusability
- Leverage tools and langage capabilities
- Improve startup time?
- Reduce binary size?
- Ease unit testing

# How
- Provide a fluent API
- Make this library easily extensible
- Reuse existing WPF types
- Provide an extensive documentation

# What
Visual tree creation API

```csharp
this._content = new ContentControl { DataContext = new MyWindowDataContext() }
        .AsFluent()
        .Size(400, 150)
        .Contains(new Grid()
          .AsFluent()
          .DefaultCellSize("25", "1")
          .Cell(0, 0).Height(20).Span(2, 2)
          .Contains(ImageExtensions.Image()
            .From(@"/Resources/Queen_Jazz.png")
            .Stretch(Stretch.Uniform)
            .Margin(10)
            )
          .Cell(1, 2)
          .Contains(new CheckBox()
            .AsFluent()
            .Center()
            .Style(style)
            .Contains("Shuffle")
            .Bind(ToggleButton.IsCheckedProperty, nameof(MyWindowDataContext.IsShuffleEnabled), BindingMode.OneWay)
            )
          )
        .Initialize();
```

Style creation API
```csharp
      var fluentStyle = StyleExtensions.Style<CheckBox>()
        .When(ToggleButton.IsCheckedProperty)
        .Is(true)
        .Then(Control.FontWeightProperty, FontWeights.Bold)
        .Then(Control.ForegroundProperty, new SolidColorBrush(Colors.DarkBlue))
        .EndWhen()
        .When(UIElement.IsMouseOverProperty)
        .Is(true)
        .Then(Control.BackgroundProperty, new SolidColorBrush(Colors.Bisque))
        .EndWhen();
```

Control template creation API
```csharp
  var template = TemplateExtensions.Template<CheckBox>()
          .Factory<CheckBox, Border>()
          .Bind(Control.BackgroundProperty, Control.BackgroundProperty)
          .Factory<CheckBox, ContentPresenter>()
          .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
          .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
          .Bind(ContentPresenter.ContentProperty, ContentControl.ContentProperty)
          .Get()
```