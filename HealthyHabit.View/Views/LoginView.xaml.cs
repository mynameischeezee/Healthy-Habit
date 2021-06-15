using HealthyHabit.ViewModel;
using System.Windows.Controls;
using System.Windows;

namespace HealthyHabit.View.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Switch(object sender, System.Windows.RoutedEventArgs e)
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
