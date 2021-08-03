using Common;
using DevExpress.Mvvm.POCO;
using Ninject;
using Ninject.Modules;

namespace NinjectDI {
    public class ServiceLocator {
        readonly IKernel kernel;
        public CollectionViewModel<Person> MainViewModel => kernel.Get<CollectionViewModel<Person>>();
        public DetailViewModel<Person> DetailViewModel => kernel.Get<DetailViewModel<Person>>();

        public ServiceLocator() => kernel = new StandardKernel(new MyModule());
    }
    public class MyModule : NinjectModule {
        public override void Load() {
            Bind(typeof(IDataStorage<Person>)).To(typeof(PersonStorage)).InSingletonScope();
            Bind(typeof(IDetailViewModel), typeof(DetailViewModel<Person>)).To(ViewModelSource.GetPOCOType(typeof(DetailViewModel<Person>))).InSingletonScope();
            Bind(typeof(CollectionViewModel<Person>)).To(ViewModelSource.GetPOCOType(typeof(CollectionViewModel<Person>)));
        }
    }
}
