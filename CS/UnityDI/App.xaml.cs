using Common;
using DevExpress.Mvvm.POCO;
using System;
using System.Windows;
using Unity;

namespace UnityDI {
    public partial class App : Application, IInjectionResolver {
        IUnityContainer Container { get; set; }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            Container = new UnityContainer()
                .RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                .RegisterSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)))
                .RegisterSingleton(typeof(IDetailViewModel), typeof(DetailViewModel))
                .RegisterType(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            DISource.Resolver = this;
        }
        object IInjectionResolver.Resolve(Type type, object key, string name) {
            if(type == null)
                return null;
            if(name != null)
                return Container.Resolve(type, name);
            return Container.Resolve(type);
        }
    }
}
