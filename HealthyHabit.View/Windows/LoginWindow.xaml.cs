using HealthyHabit.ViewModel;
using System.Windows;

namespace HealthyHabit.View.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //private MainMenu Menu;
        public LoginWindow(LoginViewModel datacontext/*, MainMenu menu*/)
        {
            InitializeComponent();
            this.DataContext = datacontext;
            //this.Menu = menu;
        }

        private void Switch(object sender, RoutedEventArgs e)
        {
            if (RegisterStackPanel.Visibility == Visibility.Visible)
            {
                RegisterStackPanel.Visibility = Visibility.Hidden;
                LoginStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                RegisterStackPanel.Visibility = Visibility.Visible;
                LoginStackPanel.Visibility = Visibility.Hidden;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //    if (DataContext is IWindowLocator vm)
            //    {
            //        vm.ChangeWindow += () =>
            //        {
            //            Menu.Show();
            //            this.Close();
            //        };
            //    }
        }
    }
}
