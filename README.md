<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/387753046/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1038807)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Register a POCO View Model in a Dependency Injection Container

This example illustrates how to register a POCO View Model in a various Dependency Injection containers.

To bind a View to a ViewModel, create a MarkupExtension that resolves the correct ViewModel type, as shown in the [DISource](./CS/Common/DISource.cs) class. Register the resolver at the application startup:

``` c#
protected override void OnStartup(StartupEventArgs e) {
    base.OnStartup(e);
    Container = BuildUpContainer();
    DISource.Resolver = Resolve;
}
object Resolve(Type type, object key, string name) {
    if(type == null)
        return null;
    if(key != null)
        return Container.ResolveKeyed(key, type);
    if(name != null)
        return Container.ResolveNamed(name, type);
    return Container.Resolve(type);
}
```

Specify the DataContext in XAML in the following manner:

```
DataContext="{common:DISource Type=common:MainViewModel}"
```

To use a POCO View Model in a DI container, use the `ViewModelSource.GetPOCOType` method to register the POCO type generated in runtime:

``` c# 
Container.RegisterType(typeof(MainViewModel), ViewModelSource.GetPOCOType(typeof(MainViewModel)));
```


<!-- default file list -->
## Files to Look At

* [AutofacDI](./CS/AutofacDI/App.xaml.cs)
* [DryIocDI](./CS/DryIocDI/App.xaml.cs)
* [MicrosoftDI](./CS/MicrosoftDI/App.xaml.cs)
* [NinjectDI](./CS/NinjectDI/App.xaml.cs)
* [PrismDI](./CS/PrismDI/App.xaml.cs)
* [SimpleInjectorDI](./CS/SimpleInjectorDI/App.xaml.cs)
* [UnityDI](./CS/UnityDI/App.xaml.cs)
<!-- default file list end -->

## Documentation
* [Runtime-generated POCO View Models](https://docs.devexpress.com/WPF/17352/mvvm-framework/viewmodels/runtime-generated-poco-viewmodels)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-mvvm-framework-register-poco-type-in-dependency-injection-container&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-mvvm-framework-register-poco-type-in-dependency-injection-container&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
