# Getting Started for Xamarin.Forms Charts
This is demo application of Xamarin.Forms SfChart control. The minimal set of required properties have been configured in this project to get started with SfChart in Xamarin.Forms.

For more details please refer the Xamarin.Forms SfChart UG documentation [Getting Started](https://help.syncfusion.com/xamarin/sfchart/getting-started?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) link.

## <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples).
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## <a name="description"></a>Description ##

### Initialize Chart

Import the [`SfChart`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart.html) namespace as shown below in your respective Page,

###### Xaml
```xaml
xmlns:chart="clr-namespace:Syncfusion.SfChart.XForms;assembly=Syncfusion.SfChart.XForms" 
```
###### C#
```C#
using Syncfusion.SfChart.XForms;
```

Then initialize an empty chart with [`PrimaryAxis`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart~PrimaryAxis.html) and [`SecondaryAxis`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart~SecondaryAxis.html) as shown below,

###### Xaml
```xaml
<chart:SfChart>

<chart:SfChart.PrimaryAxis>
    <chart:CategoryAxis/>
</chart:SfChart.PrimaryAxis>

<chart:SfChart.SecondaryAxis>
    <chart:NumericalAxis/>
</chart:SfChart.SecondaryAxis>

</chart:SfChart>
```
###### C#
```C#
SfChart chart = new SfChart();

//Initializing Primary Axis
CategoryAxis primaryAxis = new CategoryAxis();
chart.PrimaryAxis = primaryAxis;

//Initializing Secondary Axis
NumericalAxis secondaryAxis  =  new NumericalAxis  ();
chart.SecondaryAxis = secondaryAxis;

this.Content = chart;
```

### Initialize view model

Now, let us define a simple data model that represents a data point in [`SfChart`.](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart.html)

```C#
public class Person   
{   
    public string Name { get; set; }

    public double Height { get; set; }
}
``` 

Next, create a view model class and initialize a list of `Person` objects as shown below,

```C#
public class ViewModel  
{
    public List<Person> Data { get; set; }      

    public ViewModel()       
    {
        Data = new List<Person>()
        {
            new Person { Name = "David", Height = 180 },
            new Person { Name = "Michael", Height = 170 },
            new Person { Name = "Steve", Height = 160 },
            new Person { Name = "Joel", Height = 182 }
        }; 
    }
}
```

Set the `ViewModel` instance as the `BindingContext` of your Page; this is done to bind properties of `ViewModel` to [`SfChart`.](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart.html)

 Add namespace of `ViewModel` class in your XAML page if you prefer to set `BindingContext` in XAML.

###### Xaml
```Xaml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
x:Class="ChartDemo.MainPage"
xmlns:chart="clr-namespace:Syncfusion.SfChart.XForms;assembly=Syncfusion.SfChart.XForms"
xmlns:local="clr-namespace:ChartDemo"> 

<ContentPage.BindingContext>
    <local:ViewModel></local:ViewModel>
</ContentPage.BindingContext>

</ContentPage>
```
###### C#
```C#
this.BindingContext = new ViewModel();
```
### Populate Chart with data

As we are going to visualize the comparison of heights in the data model, add [`ColumnSeries`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.ColumnSeries.html) to [`SfChart.Series`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart~Series.html) property, and then bind the Data property of the above `ViewModel` to the [`ColumnSeries.ItemsSource`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.ChartSeries~ItemsSource.html) property as shown below.

You need to set [`XBindingPath`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.ChartSeries~XBindingPath.html) and [`YBindingPath`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.XyDataSeries~YBindingPath.html) properties, so that [`SfChart`](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfChart.XForms~Syncfusion.SfChart.XForms.SfChart.html) would fetch values from the respective properties in the data model to plot the series.

###### Xaml
```xaml
<ContentPage.BindingContext>
    <local:ViewModel/>
</ContentPage.BindingContext>

<chart:SfChart>

<chart:SfChart.PrimaryAxis>
    <chart:CategoryAxis>
        <chart:CategoryAxis.Title>
            <chart:ChartAxisTitle Text="Name"> </chart:ChartAxisTitle>
        </chart:CategoryAxis.Title>
    </chart:CategoryAxis>
</chart:SfChart.PrimaryAxis>

<chart:SfChart.SecondaryAxis>
    <chart:NumericalAxis>
        <chart:NumericalAxis.Title>
            <chart:ChartAxisTitle Text="Height (in cm)"></chart:ChartAxisTitle>
        </chart:NumericalAxis.Title>      
    </chart:NumericalAxis>   
</chart:SfChart.SecondaryAxis>

<chart:SfChart.Series>
    <chart:ColumnSeries ItemsSource="{Binding Data}" XBindingPath="Name" YBindingPath="Height"/>
</chart:SfChart.Series>

</chart:SfChart> 
```

###### C#
```C#
this.BindingContext = new ViewModel();
SfChart chart = new SfChart();

//Initializing primary axis
CategoryAxis primaryAxis = new CategoryAxis();
primaryAxis.Title.Text = "Name";
chart.PrimaryAxis = primaryAxis;

//Initializing secondary Axis
NumericalAxis secondaryAxis = new NumericalAxis();
secondaryAxis.Title.Text = "Height (in cm)";
chart.SecondaryAxis = secondaryAxis;

//Initializing column series
ColumnSeries series = new ColumnSeries();
series.SetBinding(ChartSeries.ItemsSourceProperty, "Data");
series.XBindingPath = "Name";
series.YBindingPath = "Height";
chart.Series.Add(series);

this.Content = chart;
```

## <a name="output"></a>Output ##

![Xamarin.Forms Getting_Started Chart image](Getting_Started_Chart_image.png)

## Related links
[Learn More about Xamarin Charts](https://www.syncfusion.com/xamarin-ui-controls/xamarin-charts/?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) <br/><br/>
[Download Free Trial](https://www.syncfusion.com/downloads?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) <br/><br/>
[Pricing](https://www.syncfusion.com/sales/products/xamarin?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) <br/><br/>
[Documentation](https://help.syncfusion.com/xamarin/charts/getting-started?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) <br/><br/>
[Online Examples](https://github.com/syncfusion/xamarin-demos/tree/master/Forms/Chart?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) <br/><br/>
[Community Forums](https://www.syncfusion.com/forums/xamarin.forms/sfchart?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) <br/><br/>
[Suggest a feature](https://www.syncfusion.com/feedback/xamarin-forms?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples)

## About Syncfusion Xamarin.Forms
Syncfusion's [Xamarin.Forms](https://www.syncfusion.com/xamarin-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples) library offers over 155 UI components to create cross-platform native mobile apps for iOS, Android, UWP and macOS platforms from a single C# code base. In addition to Charts, we provide popular Xamarin components such as [DataGrid](https://www.syncfusion.com/xamarin-ui-controls/xamarin-datagrid?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[Scheduler](https://www.syncfusion.com/xamarin-ui-controls/xamarin-scheduler?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples), [Diagram](https://www.syncfusion.com/xamarin-ui-controls/xamarin-diagram?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples), and [Maps](https://www.syncfusion.com/xamarin-ui-controls/xamarin-maps?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples).

## About Syncfusion
Founded in 2001 and headquartered in Research Triangle Park, N.C., Syncfusion has more than 23,000+ customers and more than 1 million users, including large financial institutions, Fortune 500 companies, and global IT consultancies.
 
Today, we provide 1600+ controls and frameworks for web
([Blazor](https://www.syncfusion.com/blazor-components?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[ASP.NET Core](https://www.syncfusion.com/aspnet-core-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[ASP.NET MVC](https://www.syncfusion.com/aspnet-mvc-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[ASP.NET WebForms](https://www.syncfusion.com/jquery/aspnet-webforms-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[JavaScript](https://www.syncfusion.com/javascript-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[Angular](https://www.syncfusion.com/angular-ui-components?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[React](https://www.syncfusion.com/react-ui-components?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[Vue](https://www.syncfusion.com/vue-ui-components?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
and 
[Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples)),
mobile
([Xamarin](https://www.syncfusion.com/xamarin-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[UWP](https://www.syncfusion.com/uwp-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
and
[JavaScript](https://www.syncfusion.com/javascript-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples)),
and desktop development ([Windows
Forms](https://www.syncfusion.com/winforms-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[WPF](https://www.syncfusion.com/wpf-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[WinUI(Preview)](https://www.syncfusion.com/winui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples),
[Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples)
and
[UWP](https://www.syncfusion.com/uwp-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples)).
We provide ready-to-deploy enterprise software for dashboards, reports,
data integration, and big data processing. Many customers have saved
millions in licensing fees by deploying our software.

		
<hr style="height:0.3px;border:none;color:lightgrey;background-color:lightgrey;" />

<p align="center">
  <a href="mailto:sales@syncfusion.com?Subject=Syncfusion Xamarin Charts - Github" target="_top">sales@syncfusion.com</a> | <a href="https://www.syncfusion.com?utm_source=github&utm_medium=listing&utm_campaign=xamarin-chars-github-samples">www.syncfusion.com</a> | 1-888-9 DOTNET <br>
</p>




