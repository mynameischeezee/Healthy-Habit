using HealthyHabit.DAL.Implementation;
using HealthyHabit.View.Views;
using HealthyHabit.ViewModel;
using HealthyHabit.BL.Implementation;
using HealthyHabit.BL.Abstract;
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
using HealthyHabit.Models;

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
            ServiceProvider = Configure().BuildServiceProvider();
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
                   .AddSingleton<SettingsWindow>()
                   .AddSingleton<HabitWindow>()
                   .AddSingleton<ChartsWindow>()
                   .AddSingleton<LoginViewModel>()
                   .AddSingleton<MainMenuViewModel>()
                   .AddSingleton<SettingsViewModel>()
                   .AddSingleton<HabitViewModel>()
                   .AddSingleton<ChartViewModel>()
                   .AddSingleton<IAccountHolder<User>, AccountHolder>()
                   .AddTransient<IAuthenticationService<SystemContextSQL>, AuthenticationService>()
                   .AddTransient<IHabitService<SystemContextSQL, Habit>, HabitService>()
                   .AddTransient<IUserService<SystemContextSQL, User>, UserService>()
                   .AddTransient<IChartService, ChartService>()
                   .AddTransient<IHashService, HashService>()
                   .AddTransient<ISaltService, SaltService>();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            ServiceProvider.GetRequiredService<SystemContextSQL>().Dispose();
            base.OnExit(e);
        }
    }

}
