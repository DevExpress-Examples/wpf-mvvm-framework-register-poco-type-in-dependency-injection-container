using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Windows;

namespace PrismDI {
    public partial class App : PrismApplication {
        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                             .RegisterManySingleton(ViewModelSource.GetPOCOType(typeof(DetailViewModel)), typeof(DetailViewModel), typeof(IDetailViewModel))
                             .Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
        }

        protected override Window CreateShell() {
            IocServiceProvider.Default.ConfigureServices(new PrismServiceProvider(Container));
            return Container.Resolve<MainView>();
        }
    }

    class PrismServiceProvider : IServiceProvider {
        readonly IContainerProvider container;
        public PrismServiceProvider(IContainerProvider container) {
            this.container = container;
        }
        public object GetService(Type serviceType) {
            try { return container.Resolve(serviceType); }
            catch { return null; }
        }
    }
}
