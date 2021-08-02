using Common;
using DevExpress.Mvvm.POCO;
using System.Windows;
using Unity;

namespace UnityDI {
    public partial class App : Application { }

    public class ServiceLocator {
        readonly IUnityContainer container;
        public CollectionViewModel<Person> MainViewModel => container.Resolve<CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => container.Resolve<DetailViewModel<Person>>();

        public ServiceLocator() =>
            container = new UnityContainer().RegisterSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                                            .RegisterSingleton(typeof(DetailViewModel<Person>), ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)))
                                            .RegisterSingleton(typeof(IDetailViewModel), typeof(DetailViewModel<Person>))
                                            .RegisterType(typeof(CollectionViewModel<Person>), ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)));
    }
}
