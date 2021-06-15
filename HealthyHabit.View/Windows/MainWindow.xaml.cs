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

namespace HealthyHabit.View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel datacontext)
        {
            InitializeComponent();
            this.DataContext = datacontext;
        }

        private void NavView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            UpdateViewbtn.Command.Execute(((ModernWpf.Controls.NavigationViewItem)sender.SelectedItem).Tag.ToString());
        }

    }
}
