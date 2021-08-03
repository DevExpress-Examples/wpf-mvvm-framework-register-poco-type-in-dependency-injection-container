using Common;
using DevExpress.Mvvm.POCO;
using DryIoc;
using System;

namespace DryIocDI {
    public class ServiceLocator {
        readonly IContainer container;
        public CollectionViewModel<Person> MainViewModel => container.Resolve<CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => container.Resolve<DetailViewModel<Person>>();

        public ServiceLocator() {
            container = new Container();
            container.Register(typeof(IDataStorage<Person>), typeof(PersonStorage), Reuse.Singleton);
            container.RegisterMany(new Type[] { typeof(IDetailViewModel), typeof(DetailViewModel<Person>) }, ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>)), Reuse.Singleton);
            container.Register(typeof(CollectionViewModel<Person>), ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)));
        }
    }
}
