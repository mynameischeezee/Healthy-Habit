using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
namespace HealthyHabit.ViewModel
{
    public class SwitchToLoginCommand : ICommand
    {
        public SwitchToLoginCommand(MainViewModel viewModel, LoginViewModel loginViewModel)
        {
            this.viewModel = viewModel;
            this.loginViewModel = loginViewModel;
        }

        private MainViewModel viewModel { get; set; }
        private LoginViewModel loginViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SelectedViewModel = loginViewModel;
        }
    }
}
