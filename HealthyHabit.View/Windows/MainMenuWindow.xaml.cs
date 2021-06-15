using HealthyHabit.ViewModel;
using System;
using System.Windows;

namespace HealthyHabit.View.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu(MainMenuViewModel datacontext)
        {
            InitializeComponent();
            this.DataContext = datacontext;
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            OnLoadStart.Command.Execute(null);
        }

        private void SwitchToAddHabit(object sender, RoutedEventArgs e)
        {
            if (icTodoList.Visibility == Visibility.Visible)
            {
                icTodoList.Visibility = Visibility.Hidden;
                AddHabitPanel.Visibility = Visibility.Visible;
                StatisticsArea.Visibility = Visibility.Hidden;
            }
            else
            {
                icTodoList.Visibility = Visibility.Visible;
                AddHabitPanel.Visibility = Visibility.Hidden;
                StatisticsArea.Visibility = Visibility.Visible;
            }

        }

        private void Upd(object sender, RoutedEventArgs e)
        {
        }
    }
}
