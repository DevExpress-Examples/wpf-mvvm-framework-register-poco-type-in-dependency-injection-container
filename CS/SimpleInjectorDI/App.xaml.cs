using Common;
using DevExpress.Mvvm.POCO;
using SimpleInjector;
using System;
using System.Windows;

namespace SimpleInjectorDI {
    public partial class App : Application, IInjectionResolver {
        Container Container { get; set; }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            Container = new Container();
            Container.RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage));
            Container.RegisterSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
            Container.RegisterSingleton(typeof(IDetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
            Container.Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            DISource.Resolver = this;
        }
        object IInjectionResolver.Resolve(Type type, object key, string name) => type == null ? null : Container.GetInstance(type);
    }
}
