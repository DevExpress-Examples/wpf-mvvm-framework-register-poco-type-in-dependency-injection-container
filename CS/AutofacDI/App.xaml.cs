using Autofac;
using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Windows;

namespace AutofacDI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(PersonStorage)).As(typeof(IDataStorage<Person>)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(DetailViewModel))).As(typeof(IDetailViewModel), typeof(DetailViewModel)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CollectionViewModel))).As(typeof(CollectionViewModel));
            IContainer container = builder.Build();
            IocServiceProvider.Default.ConfigureServices(new AutofacServiceProvider(container));
            base.OnStartup(e);
        }
    }

    class AutofacServiceProvider : IServiceProvider {
        readonly IContainer container;
        public AutofacServiceProvider(IContainer container) {
            this.container = container;
        }
        public object GetService(Type serviceType) {
            return container.IsRegistered(serviceType) ? container.Resolve(serviceType) : null;
        }
    }
}
