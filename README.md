[![build status](https://gitlab.com/ju2pom/FluentWPF/badges/master/build.svg)](https://gitlab.com/ju2pom/FluentWPF/commits/master)

# FluentWPF

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
var style = StyleExtensions.Create()
    .Set(Control.ForegroundProperty, colors.Text.Normal)
    .When(TriggerExtensions.Property(ToggleButton.IsCheckedProperty)
      .Is(true)
      .Then(Control.FontWeightProperty, FontWeights.Bold)
      .Then(Control.ForegroundProperty, colors.Control.Selected))
    .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
      .Is(true)
      .Then(Control.BackgroundProperty, colors.Control.Over))
    .When(TriggerExtensions.Property(FrameworkElement.TagProperty)
      .Is("test")
      .Then(ContentControl.ContentProperty, null))
    .Template(template)
    .AsStyle<CheckBox>();
```

Control template creation API
```csharp
var template = TemplateExtensions.Create<Border>()
    .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
    .TemplateBinding(Control.BorderBrushProperty, Control.BorderThicknessProperty)
    .TemplateBinding(Control.BorderThicknessProperty, Control.BorderThicknessProperty)
    .Contains<StackPanel>()
    .Set(StackPanel.OrientationProperty, Orientation.Horizontal)
    .Contains(TemplateExtensions.Create<Ellipse>()
      .Set(FrameworkElement.WidthProperty, 8d)
      .Set(FrameworkElement.HeightProperty, 8d)
      .TemplateBinding(Shape.FillProperty, Control.ForegroundProperty))
    .Contains(TemplateExtensions.Create<ContentPresenter>()
      .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
      .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
      .TemplateBinding(ContentPresenter.ContentProperty, ContentControl.ContentProperty))
    .AsControlTemplate<CheckBox>();
```
# FluentWPF vs Xaml:

*FluentWPF*

```csharp
var TemplateExtensions.Create<Border>()
    .TemplateBinding(Control.BackgroundProperty, Control.BackgroundProperty)
    .Contains<ContentPresenter>()
    .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center)
    .Set(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center)
    .TemplateBinding(ContentPresenter.ContentProperty, ContentControl.ContentProperty)
    .AsControlTemplate<CheckBox>();

var NiceCheckBox = StyleExtensions.Create()
    .When(TriggerExtensions.Property(ToggleButton.IsCheckedProperty)
      .Is(true)
      .Then(Control.FontWeightProperty, FontWeights.Bold)
      .Then(Control.ForegroundProperty, new SolidColorBrush(Colors.DarkBlue)))
    .When(TriggerExtensions.Property(UIElement.IsMouseOverProperty)
      .Is(true)
      .Then(Control.BackgroundProperty, new SolidColorBrush(Colors.Bisque)))
    .Template(template)
    .AsStyle<CheckBox>();
```    
*XAML*

```xml
<ControlTemplate x:Key="NiceCheckBoxTemplate" TargetType="CheckBox">
  <Border x:Name="Border"
    Background="{TemplateBinding Background}">
    <ContentPresenter
      HorizontalAlignment="Center"
      VerticalAlignment="Center"
      />
  </Border>
</ControlTemplate>

<Style x:Key="NiceCheckBox" TargetType="CheckBox">
  <Setter Property="Template" Value="{StaticResource NiceCheckBoxTemplate}">
  <Style.Triggers>
    <Trigger Property="IsChecked" Value="True">
      <Setter Property="FontWeight" Value="Bold" />
      <Setter Property="Foreground" Value="DarkBlue" />
    </Trigger>
    <Trigger Property="IsMouseOver" Value="True">
      <Setter Property="Background" Value="Bisque" />
    </Trigger>
  </Style.Triggers>
</Style>
  ```
  
# Roadmap
- Cover same functionalities as XAML
  - Support animations
  - Support triggers
  - Support behaviors
- Write samples
- Offer a code friendly Theme engine
- More samples
- Provide Visual studio code snippets
- API documention (or more samples)
- Extend the API functionalities beyond XAML
  - Leverage lambdas (for triggers?)
  - Support inheritance/mixins for styles
- Further reduce API verbosity