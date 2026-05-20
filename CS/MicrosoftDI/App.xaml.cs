using Common;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace MicrosoftDI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            IServiceProvider services = new ServiceCollection()
                .AddSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                .AddSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)))
                .AddSingleton(typeof(IDetailViewModel), sp => sp.GetService(typeof(DetailViewModel)))
                .AddTransient(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)))
                .BuildServiceProvider();
            IocServiceProvider.Default.ConfigureServices(services);
            base.OnStartup(e);
        }
    }
}
