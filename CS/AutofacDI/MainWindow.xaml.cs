using Autofac;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AutofacDI {
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
        readonly IContainer container;
        public MainViewModel ViewModel => (MainViewModel)container.Resolve(ViewModelSource.GetPOCOType(typeof(MainViewModel)));

        public ServiceLocator() => container = BuildUpContainer();
        IContainer BuildUpContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(DetailViewModel))).As<IDetailViewModel>();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(MainViewModel))).AsSelf();
            return builder.Build();
        }
    }
}
