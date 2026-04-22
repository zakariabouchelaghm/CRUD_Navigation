using CRUD_Navigation.DbContexts;
using CRUD_Navigation.Models;
using CRUD_Navigation.Services.AddElementService;
using CRUD_Navigation.Services.DeleteElementService;
using CRUD_Navigation.Services.ListElementsService;
using CRUD_Navigation.Services.ModifyElementService;
using CRUD_Navigation.Services.SearchElementService;
using CRUD_Navigation.Services.SortListService;
using CRUD_Navigation.Stores;
using CRUD_Navigation.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CRUD_Navigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
       
        public  App()
        {
           _host= Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                string connectionString = hostContext.Configuration.GetConnectionString("default");
                services.AddSingleton(new CRUDDbContextFactory(connectionString));
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<IListElements, DatabaseListElements>();
                services.AddSingleton<IAddElement, DatabaseAddElement>();
                services.AddSingleton<ISearchElement, DatabaseSearchElement>();
                services.AddSingleton<IDeleteService, DatabaseDeleteElement>();
                services.AddSingleton<IModifyElement, DatabaseModifyElement>();
                services.AddSingleton<ISortService, DatabaseSortList>();
                services.AddSingleton<CRUD>((s) =>
                {
                    string storeName = hostContext.Configuration.GetValue<string>("CRUDName") ?? "Default_CRUD";
                    return new CRUD(
                        storeName,
                        s.GetRequiredService<IListElements>()!, s.GetRequiredService<IAddElement>()!, s.GetRequiredService<ISearchElement>()!, s.GetRequiredService<IDeleteService>()!,
                        s.GetRequiredService<IModifyElement>()!, s.GetRequiredService<ISortService>()!
                        );
                });
                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {


                    DataContext = s.GetRequiredService<MainViewModel>()

                });
            }).Build();
            

            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            CRUDDbContextFactory crudDbContext = _host.Services.GetRequiredService<CRUDDbContextFactory>();
            using (CRUDDbContext context = crudDbContext.CreateDbContext())
            {
                context.Database.Migrate();
            }
            NavigationStore navigationStore = _host.Services.GetRequiredService<NavigationStore>();
            CRUD store = _host.Services.GetRequiredService<CRUD>();
            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }

}
