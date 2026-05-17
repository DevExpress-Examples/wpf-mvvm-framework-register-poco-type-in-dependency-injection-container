using Common;
using DevExpress.Mvvm.POCO;
using DryIoc;
using System;
using System.Windows;

namespace DryIocDI {
    public partial class App : Application {
        IContainer container;
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            container = new Container();
            container.Register(typeof(IDataStorage<Person>), typeof(PersonStorage), Reuse.Singleton);
            container.RegisterMany(new Type[] { typeof(IDetailViewModel), typeof(DetailViewModel) }, ViewModelSource.GetPOCOType(typeof(DetailViewModel)), Reuse.Singleton);
            container.Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            DISource.Resolver = Resolve;
        }
        object Resolve(Type type, object key, string name) {
            if(type == null)
                return null;
            if(key != null)
                return container.Resolve(type, key);
            return container.Resolve(type);
        }
    }
}
