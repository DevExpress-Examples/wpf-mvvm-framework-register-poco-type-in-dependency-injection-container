using Common;
using DevExpress.Mvvm.POCO;
using SimpleInjector;
using System;
using System.Windows;

namespace SimpleInjectorDI {
    public partial class App : Application {
        Container container;
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            container = new Container();
            container.RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage));
            container.RegisterSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
            container.RegisterSingleton(typeof(IDetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
            container.Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            DISource.Resolver = Resolve;
        }
        object Resolve(Type type, object key, string name) => type == null ? null : container.GetInstance(type);
    }
}
