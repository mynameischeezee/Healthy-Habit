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
        NotificationManager notificationManager = new NotificationManager();
        public LoginWindow(LoginViewModel datacontext)
        {
            InitializeComponent();
            this.DataContext = datacontext;
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
    }
}
