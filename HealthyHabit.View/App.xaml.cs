using HealthyHabit.DAL.Implementation;
using HealthyHabit.View.Views;
using HealthyHabit.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HealthyHabit.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }
        private ServiceProvider ServiceProvider { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceProvider = Configure()
                            .BuildServiceProvider();
            ServiceProvider.GetRequiredService<LoginWindow>().Show();
        }
        private IServiceCollection Configure()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory() + @"/Configuration/")
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            ServiceCollection services = new ServiceCollection();
            return services.AddDbContext<SystemContextSQL>
                   (optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DockerMsSqlDB")))
                   .AddSingleton<LoginWindow>()
                   .AddSingleton<MainMenu>()
                   .AddSingleton<MainViewModel>();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            ServiceProvider.GetRequiredService<SystemContextSQL>();
            base.OnExit(e);
        }
    }

}
