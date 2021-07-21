using Autofac;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System.Collections.ObjectModel;
using System.Windows;

namespace AutofacDI {
    public partial class MainWindow : Window {
        public MainWindow() => InitializeComponent();
    }

    public interface ILogger {
        ObservableCollection<string> Logs { get; set; }
        string GetSignature();
    }
    public class Logger : ILogger {
        public ObservableCollection<string> Logs { get; set; } = new ObservableCollection<string>();
        public string GetSignature() => "From Logger class";
    }

    [POCOViewModel]
    public class MainViewModel {
        ILogger logger;
        public ObservableCollection<string> Logs => logger.Logs;
        public MainViewModel(ILogger logger) => this.logger = logger;
    }

    [POCOViewModel]
    public class LoggerViewModel {
        ILogger logger;
        public virtual string Text { get; set; }
        public LoggerViewModel(ILogger logger) => this.logger = logger;
        public void PushText() {
            AddStringToLog(Text);
            Text = string.Empty;
        }
        public bool CanPushText() => !string.IsNullOrEmpty(Text);
        public void PushSignature() => AddStringToLog(logger.GetSignature());
        void AddStringToLog(string str) => logger.Logs.Add(str);
    }

    public class ServiceLocator {
        readonly IContainer container;
        public MainViewModel MainViewModel => (MainViewModel)container.Resolve(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
        public LoggerViewModel LoggerViewModel => (LoggerViewModel)container.Resolve(ViewModelSource.GetPOCOType(typeof(LoggerViewModel)));

        public ServiceLocator() => container = BuildUpContainer();
        IContainer BuildUpContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(Logger)).As(typeof(ILogger)).SingleInstance();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(LoggerViewModel))).AsSelf();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(MainViewModel))).AsSelf();
            return builder.Build();
        }
    }
}
