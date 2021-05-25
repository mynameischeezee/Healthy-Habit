using Caliburn.Micro;
using HealthyHabit.BL.Abstract;
using HealthyHabit.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddHabitWindow.xaml
    /// </summary>
    public partial class AddHabitWindow : Window
    {
        public AddHabitWindow(AddHabitViewModel datacontext)
        {
            this.DataContext = datacontext;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
