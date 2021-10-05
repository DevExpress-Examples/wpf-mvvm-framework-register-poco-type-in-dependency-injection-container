using Common;
using DevExpress.Mvvm.POCO;
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftDI {
    public partial class App : Application {
        ServiceProvider ServiceProvider { get; set; }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            ServiceProvider = new ServiceCollection()
                .AddSingleton(typeof(IDataStorage<Person>), typeof(PersonStorage))
                .AddSingleton(typeof(DetailViewModel), ViewModelSource.GetPOCOType(typeof(DetailViewModel)))
                .AddSingleton(typeof(IDetailViewModel), (sp) => sp.GetService<DetailViewModel>())
                .AddSingleton(typeof(CollectionViewModel), ViewModelSource.GetPOCOType(typeof(CollectionViewModel)))
                .BuildServiceProvider();
            DISource.Resolver = Resolve;
        }
        object Resolve(Type type, object key, string name) => type == null ? null : ServiceProvider.GetService(type);
    }
}
