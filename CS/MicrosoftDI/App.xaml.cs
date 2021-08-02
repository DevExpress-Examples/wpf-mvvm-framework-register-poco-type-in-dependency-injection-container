using Common;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MicrosoftDI {
    public partial class App : Application { }

    public class ServiceLocator {
        readonly ServiceProvider serviceProvider;
        public CollectionViewModel<Person> MainViewModel => serviceProvider.GetService< CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => (DetailViewModel<Person>)serviceProvider.GetService<IDetailViewModel>();

        public ServiceLocator() =>
            serviceProvider = new ServiceCollection().AddSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                                                     .AddSingleton(typeof(DetailViewModel<Person>), ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)))
                                                     .AddSingleton(typeof(IDetailViewModel), typeof(DetailViewModel<Person>))
                                                     .AddSingleton(typeof(CollectionViewModel<Person>), ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)))
                                                     .BuildServiceProvider();
    }
}
