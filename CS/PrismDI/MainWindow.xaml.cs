﻿using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace PrismDI {
    public partial class MainWindow : Window {
        public MainWindow() => InitializeComponent();
    }

    [POCOViewModel]
    public class MainWindowViewModel {
        public virtual IDetailViewModel DetailViewModel { get; set; }
        public MainWindowViewModel(IDetailViewModel detailViewModel) => DetailViewModel = detailViewModel;
    }

    public interface IDetailViewModel {
        public ObservableCollection<string> Items { get; set; }
    }
    [POCOViewModel]
    public class DetailViewModel : IDetailViewModel {
        public virtual ObservableCollection<string> Items { get; set; }
        public DetailViewModel() => Items = new(Enumerable.Range(0, 10).Select(i => "String " + i));
    }
}
