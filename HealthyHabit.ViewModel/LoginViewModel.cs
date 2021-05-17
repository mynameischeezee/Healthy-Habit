using HealthyHabit.DAL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.Models;
using HealthyHabit.ViewModel.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Wpf.Core;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.VisualStudio.PlatformUI;

namespace HealthyHabit.ViewModel
{
    public class LoginViewModel : ViewModelBase, IWindowLocator
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IAuthenticationService<SystemContextSQL> authenticationService { get; private set; }
        public LoginViewModel(SystemContextSQL context, IAuthenticationService<SystemContextSQL> authenticationService)
        {
            this.SystemContext = context;
            this.authenticationService = authenticationService;

        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(_username)); }
        }
        private string _mail;
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; OnPropertyChanged(nameof(_mail)); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(_password)); }
        }
        public ICommand LoginCommand
        {
            get { return new DelegateCommand<object>(_LoginCommand, CanExecuteLogin); }
        }
        private void _LoginCommand(object param)
        {
            var passwordBox = param as PasswordBox;
            if (passwordBox == null)
                return;
            this.Password = passwordBox.Password;
            authenticationService.Login(SystemContext, Username, Password);
            OpenMainMenuCommand.Execute("");
        }
        public ICommand RegisterCommand
        {
            get { return new DelegateCommand<object>(_RegisterCommand, CanExecuteRegister); }
        }
        private void _RegisterCommand(object param)
        {
            var passwordBox = param as PasswordBox;
            if (passwordBox == null)
                return;
            this.Password = passwordBox.Password;
            authenticationService.Register(SystemContext, Name, Username, Mail, Password);
        }
        private bool CanExecuteLogin(object context)
        {
            if (Username == null)
            {
                return false;
            }
            return true;
        }
        private bool CanExecuteRegister(object context)
        {
            if (Username == null || Mail == null || Name == null)
            {
                return false;
            }
            return true;
        }
        public ICommand OpenMainMenuCommand
        {
            get { return new DelegateCommand<object>(_OpenMainMenuCommand, CanChange); }
        }
        private void _OpenMainMenuCommand(object param)
        {
            ChangeWindow?.Invoke();
        }
        public Action ChangeWindow { get; set; }

        public bool CanChange(object context)
        {
            return true;
        }
    }
}
