using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.VisualStudio.PlatformUI;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthyHabit.ViewModel
{
    public class ChangeAccountDataViewModel : ViewModelBase
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IUserService<SystemContextSQL, User> UserService { get; private set; }
        public ChangeAccountDataViewModel(SystemContextSQL context, IUserService<SystemContextSQL, User> userService)
        {
            this.SystemContext = context;
            this.UserService = userService;
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
        public ICommand ChangeAccountDataCommand
        {
            get { return new DelegateCommand<object>(_ChangeAccountDataCommand, CanExecuteChangeAccountData); }
        }
        private void _ChangeAccountDataCommand(object param)
        {
            var passwordBox = param as PasswordBox;
            if (passwordBox == null)
                return;
            this.Password = passwordBox.Password;
            UserService.Change(SystemContext, Name, Username, Mail, Password);
        }
        private bool CanExecuteChangeAccountData(object context)
        {
            if (
                Username == null
                || Mail == null
                || Name == null
                || !Mail.Contains("@")
                || !Mail.Contains(".")
                || Username.Length < 8
                || Username.Length > 20
                || Name.Length < 8
                || Name.Length > 20
                || Mail.Length < 8
                || Mail.Length > 20)
            {
                return false;
            }
            return true;
        }
    }
}
