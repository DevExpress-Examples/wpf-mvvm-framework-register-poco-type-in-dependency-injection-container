<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655772/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/t1038805)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Doctor.cs](./CS/SimpleSchedulingExample/Doctor.cs) (VB: [Doctor.vb](./VB/SimpleSchedulingExample/Doctor.vb))
* [MainViewModel.cs](./CS/SimpleSchedulingExample/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/SimpleSchedulingExample/MainViewModel.vb))
* [MainWindow.xaml](./CS/SimpleSchedulingExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/SimpleSchedulingExample/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/SimpleSchedulingExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/SimpleSchedulingExample/MainWindow.xaml.vb))
* [MedicalAppointment.cs](./CS/SimpleSchedulingExample/MedicalAppointment.cs) (VB: [MedicalAppointment.vb](./VB/SimpleSchedulingExample/MedicalAppointment.vb))
<!-- default file list end -->

# How to register a POCO View Model in a Dependency Injection container

To use a POCO View Model in a DI container, use the ViewModelSource.GetPOCOType method to register the POCO type generated in runtime:

`container = unityContainer.RegisterType(typeof(IMainViewModel), ViewModelSource.GetPOCOType(typeof(MainViewModel)));`

This example illustrates how to apply this technique to various DI containers.

<br/>
