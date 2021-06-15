using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.BL.Implementation.Class;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using HealthyHabit.View.Views;
using HealthyHabit.View.Windows;
using HealthyHabit.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
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
            ServiceProvider = Configure().BuildServiceProvider();
            ServiceProvider.GetRequiredService<MainWindow>().DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
            ServiceProvider.GetRequiredService<LoginView>().DataContext = ServiceProvider.GetRequiredService<LoginViewModel>();
            ServiceProvider.GetRequiredService<RegisterView>().DataContext = ServiceProvider.GetRequiredService<RegisterViewModel>();
            ServiceProvider.GetRequiredService<ChangeHabitView>().DataContext = ServiceProvider.GetRequiredService<ChangeHabitViewModel>();
            ServiceProvider.GetRequiredService<ChangeAccountDataView>().DataContext = ServiceProvider.GetRequiredService<ChangeAccountDataViewModel>();
            ServiceProvider.GetRequiredService<AddHabitView>().DataContext = ServiceProvider.GetRequiredService<AddHabitViewModel>();
            ServiceProvider.GetRequiredService<HabitsView>().DataContext = ServiceProvider.GetRequiredService<HabitsViewModel>();
            ServiceProvider.GetRequiredService<MainViewModel>().SelectedViewModel = ServiceProvider.GetRequiredService<LoginViewModel>();
            ServiceProvider.GetRequiredService<MainWindow>().Show();
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
                   .AddSingleton<MainWindow>()
                   .AddSingleton<LoginView>()
                   .AddSingleton<RegisterView>()
                   .AddSingleton<HabitsView>()
                   .AddSingleton<AddHabitView>()
                   .AddSingleton<ChangeHabitView>()
                   .AddSingleton<ChangeAccountDataView>()
                   .AddSingleton<MainViewModel>()
                   .AddSingleton<LoginViewModel>()
                   .AddSingleton<RegisterViewModel>()
                   .AddSingleton<HabitsViewModel>()
                   .AddSingleton<AddHabitViewModel>()
                   .AddSingleton<ChangeHabitViewModel>()
                   .AddSingleton<ChangeAccountDataViewModel>()
                   .AddSingleton<IAccountHolder<User>, AccountHolder>()
                   .AddSingleton<IHabitCompleteDateService<SystemContextSQL, Habit, HabitCompleteDate>, HabitCompleteDateService>()
                   .AddSingleton<DateIsCompletedGeneric>()
                   .AddSingleton<DateIsCompletedGenericService>()
                   .AddSingleton<MarkHabitUnit>()
                   .AddTransient<IAuthenticationService<SystemContextSQL>, AuthenticationService>()
                   .AddTransient<IHabitService<SystemContextSQL, User, Habit, Color, Plant>, HabitService>()
                   .AddTransient<IUserService<SystemContextSQL, User>, UserService>()
                   .AddTransient<IColorService<SystemContextSQL, Color>, ColorService>()
                   .AddTransient<IPlantService<SystemContextSQL, Plant>, PlantService>()
                   .AddTransient<IChartService, ChartService>()
                   .AddTransient<IUserHabitService<SystemContextSQL, User, Habit>, UserHabitService>()
                   .AddTransient<IHashService, HashService>()
                   .AddTransient<ISaltService, SaltService>()
                   .AddTransient<SwitchToRegisterCommand>();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }

}
