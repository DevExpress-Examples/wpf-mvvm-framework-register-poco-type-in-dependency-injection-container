using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MicrosoftDI {
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
        readonly ServiceProvider serviceProvider;
        public MainViewModel ViewModel => (MainViewModel)serviceProvider.GetService(ViewModelSource.GetPOCOType(typeof(MainViewModel)));

        public ServiceLocator() =>
            serviceProvider = new ServiceCollection().AddTransient(typeof(IDetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)))
                                                     .AddTransient(ViewModelSource.GetPOCOType(typeof(MainViewModel)))
                                                     .BuildServiceProvider();
    }
}
