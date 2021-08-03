using Common;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftDI {
    public class ServiceLocator {
        readonly ServiceProvider serviceProvider;
        public CollectionViewModel<Person> MainViewModel => serviceProvider.GetService<CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => serviceProvider.GetService<DetailViewModel<Person>>();

        public ServiceLocator() =>
            serviceProvider = new ServiceCollection().AddSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                                                     .AddSingleton(typeof(DetailViewModel<Person>), ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)))
                                                     .AddSingleton(typeof(IDetailViewModel), (sp) => sp.GetService<DetailViewModel<Person>>())
                                                     .AddSingleton(typeof(CollectionViewModel<Person>), ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)))
                                                     .BuildServiceProvider();
    }
}
