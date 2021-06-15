using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.BL.Implementation.Class;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;

namespace HealthyHabit.ViewModel
{
    public class HabitsViewModel : ViewModelBase
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IAccountHolder<User> Account { get; private set; }
        public IHabitService<SystemContextSQL, User, Habit, Color, Plant> HabitService { get; private set; }
        public IUserHabitService<SystemContextSQL, User, Habit> UserHabitService { get; private set; }
        public DateIsCompletedGenericService DateIsCompletedGenericService { get; private set; }
        public HabitsViewModel(SystemContextSQL context, IAccountHolder<User> account, IHabitService<SystemContextSQL, User, Habit, Color, Plant> habitService, IUserHabitService<SystemContextSQL, User, Habit> userHabitService, DateIsCompletedGenericService dateIsCompletedGenericService)
        {
            this.SystemContext = context;
            this.Account = account;
            this.HabitService = habitService;
            this.UserHabitService = userHabitService;
            this.DateIsCompletedGenericService = dateIsCompletedGenericService;
        }

        private string _Welcome;
        public string Welcome
        {
            get { return _Welcome; }
            set { _Welcome = value; OnPropertyChanged(nameof(Welcome)); }
        }

        private string _StringProgres;
        public string StringProgres
        {
            get { return _StringProgres; }
            set { _StringProgres = value; OnPropertyChanged(nameof(StringProgres)); }
        }
        private int _Progres;
        public int Progres
        {
            get { return _Progres; }
            set { _Progres = value; OnPropertyChanged(nameof(Progres)); }
        }
        private ObservableCollection<DateIsCompletedGeneric> _habitsList;

        public ObservableCollection<DateIsCompletedGeneric> HabitsList
        {
            get { return _habitsList; }
            set { _habitsList = value; OnPropertyChanged(nameof(HabitsList)); }
        }
        public string Date { get => $"{DateTime.Now.ToString("dddd", new CultureInfo("uk-UA"))}, {DateTime.Now.ToString("M", new CultureInfo("uk-UA"))} "; }

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
            this.DateIsCompletedGenericService.Account = this.Account;
            UpdateList();
            UpdateProgres();

        }
        private void UpdateProgres()
        {
            List<HabitCompleteDate> habits = SystemContext.HabitCompleteDate.Where(x => x.CompleteDate.DayOfYear == DateTime.Now.DayOfYear).ToList<HabitCompleteDate>();
            var habs = new List<HabitCompleteDate>();
            var all = this.HabitsList.Count();
            foreach (DateIsCompletedGeneric generic in this.HabitsList)
            {
                habs.Add(habits.FirstOrDefault(h => h.ID == generic.Habit.ID));
            }
            var selected = habs.Count;
            if (all != 0)
            {
                this.Progres = selected * (100 / all);
            }
            else
            {
                this.Progres = 0;
            }
            this.StringProgres = $"Виконанно {selected} з {all} звичок. {this.Progres}%";
        }
        private void UpdateList()
        {
            HabitsList = this.DateIsCompletedGenericService.InitiAlizeGenericUnit();
            OnPropertyChanged(nameof(HabitsList));
        }
    }
}
