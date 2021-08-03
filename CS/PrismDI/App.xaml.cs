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
                             .RegisterManySingleton(ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)), typeof(DetailViewModel<Person>), typeof(IDetailViewModel))
                             .Register(typeof(CollectionViewModel<Person>), ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)));

        protected override void ConfigureViewModelLocator() {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType => {
                if(viewType == typeof(MainView))
                    return ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>));
                if(viewType == typeof(DetailView))
                    return ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>));
                throw new NotSupportedException();
            });
        }

        protected override Window CreateShell() => Container.Resolve<MainView>();
    }
}
