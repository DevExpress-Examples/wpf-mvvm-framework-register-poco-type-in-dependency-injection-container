using DevExpress.Mvvm.POCO;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;

namespace PrismDI {
    public partial class App : PrismApplication {
        protected override void RegisterTypes(IContainerRegistry containerRegistry) =>
            containerRegistry.Register(typeof(IDetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));

        protected override void ConfigureViewModelLocator() {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), ViewModelSource.GetPOCOType(typeof(MainViewModel)));
        }

        protected override Window CreateShell() => Container.Resolve<MainWindow>();
    }
}
