using HealthyHabit.BL.Abstract;
using HealthyHabit.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthyHabit.View.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private readonly AddHabitWindow addHabit;
        public MainMenu(MainMenuViewModel datacontext, AddHabitWindow addHabitWindow)
        {
            InitializeComponent();
            this.DataContext = datacontext;
            addHabit = addHabitWindow;
            if (DataContext is IWindowLocator vm)
            {
                vm.ChangeWindow += () =>
                {
                    addHabit.Show();
                };
            }

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
