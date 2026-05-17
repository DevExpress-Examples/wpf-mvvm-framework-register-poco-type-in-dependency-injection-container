using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Windows;
using Unity;

namespace UnityDI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            IUnityContainer container = new UnityContainer()
                .RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                .RegisterSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)))
                .RegisterSingleton(typeof(IDetailViewModel), typeof(DetailViewModel))
                .RegisterType(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            IocServiceProvider.Default.ConfigureServices(new UnityServiceProvider(container));
            base.OnStartup(e);
        }
    }

    class UnityServiceProvider : IServiceProvider {
        readonly IUnityContainer container;
        public UnityServiceProvider(IUnityContainer container) {
            this.container = container;
        }
        public object GetService(Type serviceType) {
            return container.IsRegistered(serviceType) ? container.Resolve(serviceType) : null;
        }
    }
}
