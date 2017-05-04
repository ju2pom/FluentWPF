[![build status](https://gitlab.com/ju2pom/FluentWPF/badges/master/build.svg)](https://gitlab.com/ju2pom/FluentWPF/commits/master)

# FluentWPF

FluentWPF is a library which offers an alternative Xaml.

# Why?
- Reduce verbosity
- Provide more flexibility
- Improve reusability
- Leverage tools and C# langage capabilities
- Ease unit testing

# How
- Provide a fluent API
- Make this library easily extensible
- Reuse existing WPF types
- Provide many sample usages

# What
Let's see what it looks like with some piece of code.

## Simple window
```csharp
new Window()
  .AsFluent<Window>()
  .DataContext(new RootViewModel())
  .NoBorder()
  .NoResize()
```

I hope the code is pretty straitforward but let's write the xaml equivalent:
```xml
<Window
  x:Class="SomeNameSpace.MyWindow"
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
  xmlns:local="clr-namespace:SomeNameSpace.ViewModels"
  ResizeMode="NoResize"
  WindowStyle="None"
  >
  <Window.DataContext>
   <local:RootViewModel />
  </Window.DataContext>
```

## Alignment is easy

```csharp
new Expander()
  .AsFluent()
  .Top()
  .Size(400, 400)
```

Indeed it's as easy as to align `Left` or `Right` or `Center` or `Bottom`.

## Set a property

```csharp
new TextBlock()
  .AsFluent()
  .Set(FrameworkElement.MarginProperty, new Thickness(4))
  .Set(TextBlock.TextProperty, "Some text"))
```

## Experiment with bindings

```csharp
new Button()
  .AsFluent()
  .Contains("Button1")
  .Bind(BindingExtensions
    .OneTime(ButtonBase.CommandProperty)
    .With(nameof(RootViewModel.SimpleCommand)))
```

The binding API should greatly simplify binding syntax. Sure you can bind `OneWay` or `TwoWay` or `OneWayToSource` or `OneTime`.
You can define the binding source using `With` and specify the path to the DataContext property or bind to self using `WithSelf`.

## Bindings and converters

```csharp
new ProgressBar()
  .AsFluent()
  .Bind(BindingExtensions
    .OneWay(RangeBase.ValueProperty)
    .With(nameof(SomeViewModel.Progress))
    .Convert(x => Math.Round((double) x)))
```

If you want to adapt your viewmodel's property to your view you still can provide a `IValueConverter` but you can also provide a lambda expression or a method and keep it simple.

## Create a grid and populate it

```csharp
new Grid()
  .AsFluent()
  .DefaultCellSize("*", "*")
  .Cell(GridCellExtensions.Create()
    .Contains(new Button()
      .AsFluent()
      .Contains("Button1")))
  .Cell(GridCellExtensions.Create()
    .Column(1)
    .Contains(new Button()
      .AsFluent()
      .Contains("Button2")))
```

The grid API is meant to ease dealing with grids. For exemple you don't need to first declare rows and columns.
And you can define default width and heigh and specify a specific value for any cell if wanted.
The sample above only demonstrate a very small part of the Grid API


## Simple style creation

```csharp
Style aCheckBox = StyleExtensions.Create()
    .Set(Control.ForegroundProperty, new SolidColorBrush(Colors.White))
    .Set(Control.BackgroundProperty, new SolidColorBrush(Colors.Gray))
    .AsStyle<CheckBox>();
```

Which is equivalent to: 
```xml
<Style x:Key="ACheckBox" TargetType="CheckBox">
  <Setter Property="Foreground" Value="White" />
  <Setter Property="Background" Value="Gray" />
</Style>
```

Well is this very simple exemple FluentWPF is not shorter and even a little bit more verbose.
But wait, the Triggers API and the Theme API will greatly help !

## Styles with triggers

```csharp
Style aCheckBox = StyleExtensions.Create()
  .Set(Control.ForegroundProperty, new SolidColorBrush(Colors.Gray))
  .When(TriggerExtensions
    .Property(ToggleButton.IsCheckedProperty)
    .Is(true)
    .Then(Control.FontWeightProperty, FontWeights.Bold)
    .Then(Control.ForegroundProperty, new SolidColorBrush(Colors.White))
  .AsStyle<CheckBox>();
```

Which is equivalent to:
```xml
<Style x:Key="ACheckBox" TargetType="CheckBox">
  <Setter Property="Foreground" Value="White" />
  <Style.Triggers>
    <Trigger Property="IsChecked">
      <Setter Property="FondWeight" Value="Bold" />
      <Setter Property="Foreground" Value="White" />
    </Trigger>
  </Style.Triggers>
</Style>
```

## Simple ControlTemplate

```csharp
ControlTemplate template = TemplateExtensions.Create<Border>()
  .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch)
  .Contains(TemplateExtensions.Create<ContentPresenter>())
  .AsControlTemplate<ListBoxItem>();
```

This is a very simple ControlTemplate for ListBoxItem elements.

## DataTemplate is easy too

```csharp
DataTemplate template = TemplateExtensions.Create<Border>()
  .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch)
  .Contains(TemplateExtensions.Create<ContentPresenter>())
  .AsDataTemplate<MyClass>();
```

You can use the same API to create a DataTemplate as for ControlTemplate.

## ControlTemplate with TemplateBinding

```csharp
ControlTemplate template = TemplateExtensions.Create<Border>()
  .Set(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch)
  .Contains(TemplateExtensions.Create<ContentPresenter>())
  .TemplateBinding(Border.BackgroundProperty, ListBoxItem.BackgroundProperty)
  .AsControlTemplate<ListBoxItem>();
```

## Theming ?

A work in progress will also provide a fluent API to ease theme creation.
The API will:
- provide a way to define a color palette
- provide an easy way to define default style for any control type
- take care of resource dictionary loading

# Roadmap
- Cover same functionalities as XAML
  - Support templates/styles
  - Support bindings/converters
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
