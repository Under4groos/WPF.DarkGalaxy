# WPF.DarkGalaxy

WPF Custom Window and Controls.

Controls:
<ul>
    <li>Border</li>
    <li>Button</li>
    <li>CheckBox</li>
    <li>TreeView</li>
    <li>ToggleButton</li>
    <li>TextBox</li>
    <li>ContextMenu</li>
    <li>Label</li>
    <li>ListBox</li>
</ul>
Custom controls:
<ul>
    <li>PART_Button</li>     
</ul>
Window:
<ul>
    <li>DarkWindow</li>  
</ul>

# Install
Include library in project.

App.xaml
```
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
or 
```
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Colors\BrushColors.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/Border.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/ToggleButton.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/ScrollViewer.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/Label.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/ContextMenu.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/Button.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/TreeView.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/TabItem.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/TextBox.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/CheckBox.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/ListBox.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/SvgPath.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/PART_Button.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Icons/SvgList.xaml"/>
            <ResourceDictionary Source="/WPF.DarkGalaxy;component/Themes/Default/DarkWindow.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>

```


# Using
Append in file 
```
xmlns:controls="clr-namespace:WPF.DarkGalaxy.Controls;assembly=WPF.DarkGalaxy"
xmlns:wpf="http://github.com/Under4groos/WPF.DarkGalaxy"
```
![enter image description here](https://github.com/Under4groos/WPF.DarkGalaxy/blob/master/screenshot/devenv_IuvoqRAogL.png?raw=true)



# Screenshots

![enter image description here](https://github.com/Under4groos/WPF.DarkGalaxy/blob/master/screenshot/7EVnyTZGkS.png?raw=true)
![enter image description here](https://github.com/Under4groos/WPF.DarkGalaxy/blob/master/screenshot/Ux1WoyIemu.png?raw=true)
![enter image description here](https://github.com/Under4groos/WPF.DarkGalaxy/blob/master/screenshot/odJxmOZR2H.png?raw=true)