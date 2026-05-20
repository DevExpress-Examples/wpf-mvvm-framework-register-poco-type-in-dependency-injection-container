using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Ninject;
using Ninject.Modules;
using System.Windows;

namespace NinjectDI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            IKernel kernel = new StandardKernel(new MyModule());
            IocServiceProvider.Default.ConfigureServices(kernel);
            base.OnStartup(e);
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
