using Common;
using DevExpress.Mvvm.POCO;
using SimpleInjector;
using System.Windows;

namespace SimpleInjectorDI {
    public partial class App : Application { }

    public class ServiceLocator {
        readonly Container container;
        public CollectionViewModel<Person> MainViewModel => container.GetInstance<CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => container.GetInstance<DetailViewModel<Person>>();

        public ServiceLocator() {
            container = new Container();
            container.RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage));
            container.RegisterSingleton(typeof(DetailViewModel<Person>), ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)));
            container.RegisterSingleton(typeof(IDetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)));
            container.Register(typeof(CollectionViewModel<Person>), ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)));
        }
    }
}
