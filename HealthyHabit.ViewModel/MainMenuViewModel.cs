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

namespace HealthyHabit.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IAccountHolder<User> Account { get; private set; }
        public string Welcome { get =>  $"{GetStringWelcomeByHours()}, !"; }
        public string Date { get => $"{DateTime.Now.ToString("dddd", new CultureInfo("uk-UA"))}, {DateTime.Now.ToString("M", new CultureInfo("uk-UA"))} "; }
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
    }
}
