<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/387753046/20.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1038807)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [AutofacDI](./CS/AutofacDI/App.xaml.cs)
* [DryIocDI](./CS/DryIocDI/App.xaml.cs)
* [MicrosoftDI](./CS/MicrosoftDI/App.xaml.cs)
* [NinjectDI](./CS/NinjectDI/App.xaml.cs)
* [PrismDI](./CS/PrismDI/App.xaml.cs)
* [SimpleInjectorDI](./CS/SimpleInjectorDI/App.xaml.cs)
* [UnityDI](./CS/UnityDI/App.xaml.cs)
<!-- default file list end -->

# How to register a POCO View Model in a Dependency Injection container

To use a POCO View Model in a DI container, use the ViewModelSource.GetPOCOType method to register the POCO type generated in runtime:

`container = unityContainer.RegisterType(typeof(IMainViewModel), ViewModelSource.GetPOCOType(typeof(MainViewModel)));`

Use the DISource.Resolver property to create a MarkupExtension that resolves the correct ViewModel type. Specify the DataContext in XAML in the following manner:

`DataContext="{common:DISource Type=common:CollectionViewModel}"`

This example illustrates how to apply this technique to various DI containers.

<br/>