using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HealthyHabit.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel( AddHabitViewModel addHabitViewModel, ChangeAccountDataViewModel changeAccountDataViewModel, ChangeHabitViewModel changeHabitViewModel, HabitsViewModel habitsViewModel)
        {
            this.addHabitViewModel = addHabitViewModel;
            this.changeAccountDataViewModel = changeAccountDataViewModel;
            this.changeHabitViewModel = changeHabitViewModel;
            this.habitsViewModel = habitsViewModel;
        }
        private AddHabitViewModel addHabitViewModel { get; set; }
        private ChangeAccountDataViewModel changeAccountDataViewModel { get; set; }
        private ChangeHabitViewModel changeHabitViewModel { get; set; }
        private HabitsViewModel habitsViewModel { get; set; }

        private ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateView
        {
            get { return new DelegateCommand<object>(_UpdateView, CanExecute); }
        }
        private void _UpdateView(object parameter)
        {
            if (parameter.ToString() == "AddHabitViewModel")
            {
                this.addHabitViewModel.OnLoad.Execute(null);
                this.SelectedViewModel = this.addHabitViewModel;
            }
            else if (parameter.ToString() == "ChangeAccountDataViewModel")
            {
                this.SelectedViewModel = this.changeAccountDataViewModel;
            }
            else if (parameter.ToString() == "ChangeHabitViewModel")
            {
                this.SelectedViewModel = this.changeHabitViewModel;
            }
            else if (parameter.ToString() == "HabitsViewModel")
            {
                this.habitsViewModel.OnLoad.Execute(null);
                this.SelectedViewModel = this.habitsViewModel;
            }
        }
        private bool CanExecute(object context)
        {
            return true;
        }
    }
}
