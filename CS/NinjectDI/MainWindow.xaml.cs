using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Ninject;
using Ninject.Modules;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace NinjectDI {
    public partial class MainWindow : Window {
        public MainWindow() => InitializeComponent();
    }

    [POCOViewModel]
    public class MainViewModel {
        public virtual IDetailViewModel DetailViewModel { get; set; }
        public MainViewModel(IDetailViewModel detailViewModel) => DetailViewModel = detailViewModel;
    }

    public interface IDetailViewModel {
        public ObservableCollection<string> Items { get; set; }
    }
    [POCOViewModel]
    public class DetailViewModel : IDetailViewModel {
        public virtual ObservableCollection<string> Items { get; set; }
        public DetailViewModel() => Items = new(Enumerable.Range(0, 10).Select(i => "String " + i));
    }

    public class ServiceLocator {
        readonly IKernel kernel;
        public MainViewModel ViewModel => (MainViewModel)kernel.Get(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
        public ServiceLocator() => kernel = new StandardKernel(new DetailModule());
    }
    public class DetailModule : NinjectModule {
        public override void Load() => Bind<IDetailViewModel>().To(ViewModelSource.GetPOCOType(typeof(DetailViewModel)));
    }
}
