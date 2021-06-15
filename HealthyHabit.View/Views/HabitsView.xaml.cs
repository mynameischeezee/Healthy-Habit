using HealthyHabit.ViewModel;
using System.Windows.Controls;

namespace HealthyHabit.View.Views
{
    /// <summary>
    /// Interaction logic for HabitsView.xaml
    /// </summary>
    public partial class HabitsView : UserControl
    {
        public HabitsView()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
