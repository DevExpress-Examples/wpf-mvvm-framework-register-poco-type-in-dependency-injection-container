using Autofac;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace AutofacDI {
    public partial class App : Application { }

    public class ServiceLocator {
        public readonly IContainer container;
        public CollectionViewModel MainViewModel => container.Resolve<CollectionViewModel>();
        public DetailViewModel DetailViewModel => container.Resolve<DetailViewModel>();

        public ServiceLocator() => container = BuildUpContainer();
        IContainer BuildUpContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(PersonStorage)).As(typeof(IDataStorage<Person>)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(DetailViewModel))).As(typeof(IDetailViewModel), typeof(DetailViewModel)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CollectionViewModel))).As(typeof(CollectionViewModel));
            return builder.Build();
        }
    }
}
