using Common;
using DevExpress.Mvvm.POCO;
using DryIoc;
using System;
using System.Windows;

namespace DryIocDI {
    public partial class App : Application, IInjectionResolver {
        IContainer Container { get; set; }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            Container = new Container();
            Container.Register(typeof(IDataStorage<Person>), typeof(PersonStorage), Reuse.Singleton);
            Container.RegisterMany(new Type[] { typeof(IDetailViewModel), typeof(DetailViewModel) }, ViewModelSource.GetPOCOType(typeof(DetailViewModel)), Reuse.Singleton);
            Container.Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            DISource.Resolver = this;
        }
        object IInjectionResolver.Resolve(Type type, object key, string name) {
            if(type == null)
                return null;
            if(key != null)
                return Container.Resolve(type, key);
            return Container.Resolve(type);
        }
    }
}
