using HealthyHabit.BL.Abstract;
using HealthyHabit.ViewModel;
using Notifications.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthyHabit.View.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainMenu Menu;
        public LoginWindow(LoginViewModel datacontext, MainMenu menu)
        {
            InitializeComponent();
            this.DataContext = datacontext;
            this.Menu = menu;
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
            if (DataContext is IWindowLocator vm)
            {
                vm.ChangeWindow += () =>
                {
                    Menu.Show();
                    this.Close();
                };
            }
        }
    }
}
