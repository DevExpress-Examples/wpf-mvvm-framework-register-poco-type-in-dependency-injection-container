using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using SimpleInjector;
using System.Windows;

namespace SimpleInjectorDI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            var container = new Container();
            container.RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage));
            container.RegisterSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
            container.RegisterSingleton(typeof(IDetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
            container.Register(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)));
            IocServiceProvider.Default.ConfigureServices(container);
            base.OnStartup(e);
        }
    }
}
