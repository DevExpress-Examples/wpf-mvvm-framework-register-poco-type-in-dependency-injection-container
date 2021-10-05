using Autofac;
using Common;
using DevExpress.Mvvm.POCO;
using System;
using System.Windows;

namespace AutofacDI {
    public partial class App : Application {
        IContainer Container { get; set; }
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

        static IContainer BuildUpContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(PersonStorage)).As(typeof(IDataStorage<Person>)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(DetailViewModel))).As(typeof(IDetailViewModel), typeof(DetailViewModel)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CollectionViewModel))).As(typeof(CollectionViewModel));
            return builder.Build();
        }
    }
}
