using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using SimpleInjector;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SimpleInjectorDI {
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
        readonly Container container;
        public MainViewModel ViewModel => (MainViewModel)container.GetInstance(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
        public ServiceLocator() {
            container = new Container();
            container.Register(typeof(IDetailViewModel), typeof(DetailViewModel));
            container.Register(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
        }
    }
}
