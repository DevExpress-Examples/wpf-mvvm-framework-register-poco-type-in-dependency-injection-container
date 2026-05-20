using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DryIoc;
using System;
using System.Windows;

namespace DryIocDI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            var container = new Container();
            container.Register(typeof(IDataStorage<Person>), typeof(PersonStorage), Reuse.Singleton);
            container.RegisterMany(new Type[] { typeof(IDetailViewModel), typeof(DetailViewModel) }, ViewModelSource.GetPOCOType(typeof(DetailViewModel)), Reuse.Singleton);
            container.Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            IocServiceProvider.Default.ConfigureServices(new DryIocServiceProvider(container));
            base.OnStartup(e);
        }
    }

    class DryIocServiceProvider : IServiceProvider {
        readonly IContainer container;
        public DryIocServiceProvider(IContainer container) {
            this.container = container;
        }
        public object GetService(Type serviceType) {
            return container.Resolve(serviceType, IfUnresolved.ReturnDefault);
        }
    }
}
