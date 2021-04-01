# WPFComponents
Extended WPF components

[![License: MIT](https://img.shields.io/github/license/Akeloya/WPFComponents)](https://github.com/Akeloya/WPFComponents/blob/master/LICENSE.md)
[![GitHub release](https://img.shields.io/github/v/release/Akeloya/WPFComponents.svg)](https://github.com/Akeloya/WPFComponents/releases/latest)
[![NuGet](https://img.shields.io/nuget/v/WpfExtendedControls)](https://www.nuget.org/packages/WpfExtendedControls/)


The main goal of the project is to collect controls that will facilitate the development of WPF applications.

## Target frameworks

- .Net Core 3.1
- .Net Framework 4.7.2, 4.8
- .Net 5 windows

## Included controls

- AboutApp - simple about application window with layout for licenses used in application buid (components, dll, packages, etc.)
- LabelMui - label for displaint multi-langual strings getting from application resource by name. No need define any bindings - just resource string for label.

## Future controls

- TimePicker (helps to set only time-part of date-time value)
- WPF docking manager (I found commercial controls and WinForms, not WPF)

## Contributing
This project welcomes contributions and suggestions.
The project needs help in development - adding new controls that will be available to everyone for free and improving the code.

## Using controls

### LabelMui

```xml
<UserControl xmlns:ctr="clr-namespace:WpfExtendedControls">
    <ctr:LabelMui Grid.Row="10" Grid.Column="0" ResourceKey="AboutBoxDescription"></ctr:LabelMui>
</UserControl>
```

### AboutApp

```csharp
private void About_Executed(object sender, ExecutedRoutedEventArgs e)
{
    var licenses = new List<LicenseInformation>
    {
        new LicenseInformation("Application", Encoding.UTF8.GetString(Properties.Resources.LICENSE), false)
    };
    var ab = new AboutApp(licenses,null);
    ab.Show();
}
```