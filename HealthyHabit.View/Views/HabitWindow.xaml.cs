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
    /// Interaction logic for HabitWindow.xaml
    /// </summary>
    public partial class HabitWindow : Window
    {
        public HabitWindow(HabitViewModel datacontext)
        {
            InitializeComponent();
            this.DataContext = datacontext;
        }
    }
}
