using Autofac;
using Common;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace AutofacDI {
    public partial class App : Application { }

    public class ServiceLocator {
        public readonly IContainer container;
        public CollectionViewModel<Person> MainViewModel => container.Resolve<CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => container.Resolve<DetailViewModel<Person>>();

        public ServiceLocator() => container = BuildUpContainer();
        IContainer BuildUpContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(PersonStorage)).As(typeof(IDataStorage<Person>)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>))).As(typeof(IDetailViewModel), typeof(DetailViewModel<Person>)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>))).As(typeof(CollectionViewModel<Person>));
            return builder.Build();
        }
    }
}
