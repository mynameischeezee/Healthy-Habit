using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HealthyHabit.ViewModel
{
    public class SwitchToRegisterCommand : ICommand
    {
        public SwitchToRegisterCommand(MainViewModel viewModel, RegisterViewModel registerViewModel)
        {
            this.viewModel = viewModel;
            this.registerViewModel = registerViewModel;
        }

        private MainViewModel viewModel { get; set; }
        private RegisterViewModel registerViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SelectedViewModel = registerViewModel;
        }
    }
}
