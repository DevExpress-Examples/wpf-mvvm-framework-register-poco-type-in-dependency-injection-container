using Common;
using DevExpress.Mvvm.POCO;
using Ninject.Modules;
using Ninject;
using System.Windows;
using System;

namespace NinjectDI {
    public partial class App : Application {
        IKernel kernel;
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            kernel = new StandardKernel(new MyModule());
            DISource.Resolver = Resolve;
        }
        object Resolve(Type type, object key, string name) {
            if(type == null)
                return null;
            if(name != null)
                return kernel.Get(type, name);
            return kernel.Get(type);
        }
    }

    public class MyModule : NinjectModule {
        public override void Load() {
            Bind(typeof(IDataStorage<Person>)).To(typeof(PersonStorage)).InSingletonScope();
            Bind(typeof(IDetailViewModel), typeof(DetailViewModel)).To(ViewModelSource.GetPOCOType(typeof(DetailViewModel))).InSingletonScope();
            Bind(typeof(CollectionViewModel)).To(ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
        }
    }
}
