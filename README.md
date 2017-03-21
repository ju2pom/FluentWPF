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
Here is what it currently looks like:

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
            //.Style(Theme.NiceCheckBox)
            .Contains("Shuffle")
            .Bind(ToggleButton.IsCheckedProperty, nameof(MyWindowDataContext.IsShuffleEnabled), BindingMode.OneWay)
            )
          .Cell(2, 2)
          .Contains(new CheckBox()
            .AsFluent()
            .Center()
            .Style(Theme.NiceCheckBox)
            .Contains("Loop")
            .Bind(ToggleButton.IsCheckedProperty, nameof(MyWindowDataContext.IsLoopEnabled), BindingMode.OneWay))
          .Cell(3, 0)
          .Contains(new Button()
            .AsFluent()
            .Contains("<<")
            )
          .Cell(3, 1)
          .Contains(new Button()
            .AsFluent()
            .Contains(">")
            )
          .Cell(3, 2)
          .Contains(new Button()
            .AsFluent()
            .Contains(">>")
            )
          .Cell(4, 0).Span(1, 3)
          .Contains(ProgressExtensions.ProgressBar()
            .Minium(0)
            .Maximum(100)
            .Value(50)
            .MarginTop(10)
            .MarginBottom(10)
            )
          )
        .Initialize();
```