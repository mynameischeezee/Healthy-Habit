using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HealthyHabit.ViewModel
{
    public class UpdateViewCommand : ICommand
    {
        public UpdateViewCommand(MainViewModel viewModel, AddHabitViewModel addHabitViewModel, ChangeAccountDataViewModel changeAccountDataViewModel, ChangeHabitViewModel changeHabitViewModel, HabitsViewModel habitsViewModel)
        {
            this.viewModel = viewModel;
            this.addHabitViewModel = addHabitViewModel;
            this.changeAccountDataViewModel = changeAccountDataViewModel;
            this.changeHabitViewModel = changeHabitViewModel;
            this.habitsViewModel = habitsViewModel;
        }
        private MainViewModel viewModel { get; set; }
        private AddHabitViewModel addHabitViewModel { get; set; }
        private ChangeAccountDataViewModel changeAccountDataViewModel { get; set; }
        private ChangeHabitViewModel changeHabitViewModel { get; set; }
        private HabitsViewModel habitsViewModel { get; set; }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "AddHabitViewModel")
            {
                viewModel.SelectedViewModel = this.addHabitViewModel;
            }
            else if (parameter.ToString() == "ChangeAccountDataViewModel")
            {
                viewModel.SelectedViewModel = this.changeAccountDataViewModel;
            }
            else if (parameter.ToString() == "ChangeHabitViewModel")
            {
                viewModel.SelectedViewModel = this.changeHabitViewModel;
            }
            else if (parameter.ToString() == "HabitsViewModel")
            {
                this.habitsViewModel.OnLoad.Execute(null);
                viewModel.SelectedViewModel = this.habitsViewModel;
            }
        }
    }
}
