using Autofac;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace AutofacDI {
    public partial class App : Application { }

    public class ServiceLocator {
        public readonly IContainer container;
        public CollectionViewModel MainViewModel => (CollectionViewModel)container.Resolve<ICollectionViewModel<Person>>();

        public ServiceLocator() => container = BuildUpContainer();
        IContainer BuildUpContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(PersonStorage)).As(typeof(IDataStorage<Person>));
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(DetailViewModel))).As(typeof(IDetailViewModel<Person>));
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CollectionViewModel))).As(typeof(ICollectionViewModel<Person>)).WithParameter("locator", this).SingleInstance();
            return builder.Build();
        }
    }
}
