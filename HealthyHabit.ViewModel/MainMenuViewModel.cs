using HealthyHabit.DAL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.ViewModel.Abstractions;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.VisualStudio.PlatformUI;

namespace HealthyHabit.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IAccountHolder<User> Account { get; private set; }
        private string _Welcome;
        public string Welcome
        {
            get { return _Welcome; }
            set { _Welcome = value; OnPropertyChanged(nameof(Welcome)); }
        }
        private int _Progress;
        public int Progress
        {
            get { return _Progress; }
            set { _Progress = value; OnPropertyChanged(nameof(Progress));
}
        }
        public string Date { get => $"{DateTime.Now.ToString("dddd", new CultureInfo("uk-UA"))}, {DateTime.Now.ToString("M", new CultureInfo("uk-UA"))} ";}
        public ObservableCollection<Habit> HabitsList { get; private set; }
        public MainMenuViewModel(SystemContextSQL context, IAccountHolder<User> account)
        {
            this.SystemContext = context;
            this.Account = account;

        }
        private string GetStringWelcomeByHours()
        {
            if (DateTime.Now.TimeOfDay.Hours > 12 && DateTime.Now.TimeOfDay.Hours < 18)
            {
                return "Доброго дня";
            }
            else if (DateTime.Now.TimeOfDay.Hours > 18)
            {
                return "Доброго вечора";
            }
            else if (DateTime.Now.TimeOfDay.Hours < 12)
            {
                return "Доброго ранку";
            }
            return "Вітаю";

        }
        private bool SureUCan(object context)
        {
            return true;
        }
        public ICommand OnLoad
        {
            get { return new DelegateCommand<object>(_OnLoad, SureUCan); }
        }
        private void _OnLoad(object param)
        {
            this.Welcome = $"{GetStringWelcomeByHours()}, {this.Account.GetUser().Name}!";
            this.Progress = 100;
        }
    }
}
