using Common;
using DevExpress.Mvvm.POCO;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Windows;

namespace PrismDI {
    public partial class App : PrismApplication {
        protected override void RegisterTypes(IContainerRegistry containerRegistry) =>
            containerRegistry.RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                             .RegisterManySingleton(ViewModelSource.GetPOCOType(typeof(DetailViewModel)), typeof(DetailViewModel), typeof(IDetailViewModel))
                             .Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));

        protected override void ConfigureViewModelLocator() {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType => {
                if(viewType == typeof(MainView))
                    return ViewModelSource.GetPOCOType(typeof(CollectionViewModel));
                if(viewType == typeof(DetailView))
                    return ViewModelSource.GetPOCOType(typeof(DetailViewModel));
                throw new NotSupportedException();
            });
        }

        protected override Window CreateShell() => Container.Resolve<MainView>();
    }
}
