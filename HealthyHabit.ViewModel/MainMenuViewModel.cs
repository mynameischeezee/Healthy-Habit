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
using HealthyHabit.BL.Implementation.Class;

namespace HealthyHabit.ViewModel
{
    public class MainMenuViewModel : ViewModelBase, IWindowLocator
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IAccountHolder<User> Account { get; private set; }
        public IHabitService<SystemContextSQL, User, Habit, Color, Plant> HabitService { get; private set; }
        public IUserHabitService<SystemContextSQL, User, Habit> UserHabitService { get; private set; }
        public DateIsCompletedGenericService DateIsCompletedGenericService { get; private set; }
        public MainMenuViewModel(SystemContextSQL context, IAccountHolder<User> account, IHabitService<SystemContextSQL, User, Habit, Color, Plant> habitService, IUserHabitService<SystemContextSQL, User, Habit> userHabitService, DateIsCompletedGenericService dateIsCompletedGenericService)
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
        private int _Progress;
        public int Progress
        {
            get { return _Progress; }
            set
            {
                _Progress = value; OnPropertyChanged(nameof(Progress));
            }
        }

        private string _CreateHabitDescription;
        public string CreateHabitDescription
        {
            get { return _CreateHabitDescription; }
            set { _CreateHabitDescription = value; OnPropertyChanged(nameof(CreateHabitDescription)); }
        }
        private string _CreateHabitName;
        public string CreateHabitName
        {
            get { return _CreateHabitName; }
            set { _CreateHabitName = value; OnPropertyChanged(nameof(CreateHabitName)); }
        }
        private int _CreateHabitFrequency;
        public int CreateHabitFrequency
        {
            get { return _CreateHabitFrequency; }
            set
            {
                _CreateHabitFrequency = value;
                if (_CreateHabitFrequency < 0)
                {
                    _CreateHabitFrequency = 0;
                }
                OnPropertyChanged(nameof(CreateHabitFrequency));
            }
        }
        private Color _CreateHabitSelectedColor;
        public Color CreateHabitSelectedColor
        {
            get { return _CreateHabitSelectedColor; }
            set { _CreateHabitSelectedColor = value; OnPropertyChanged(nameof(CreateHabitSelectedColor)); }
        }
        private Plant _CreateHabitSelectedPlant;
        public Plant CreateHabitSelectedPlant
        {
            get { return _CreateHabitSelectedPlant; }
            set { _CreateHabitSelectedPlant = value; OnPropertyChanged(nameof(CreateHabitSelectedPlant)); }
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
        public ObservableCollection<Color> ColorsList { get; private set; }
        public ObservableCollection<Plant> PLantsList { get; private set; }
        public ObservableCollection<DateIsCompletedGeneric> HabitsList { get; private set; }

        public string Date { get => $"{DateTime.Now.ToString("dddd", new CultureInfo("uk-UA"))}, {DateTime.Now.ToString("M", new CultureInfo("uk-UA"))} "; }
        public ICommand CreateNewHabit => new DelegateCommand<object>(_CreateNewHabit, CanCreate);

        private void _CreateNewHabit(object param)
        {
            this.HabitService.Create(SystemContext, Account.GetUser(), CreateHabitName, CreateHabitDescription, 0, CreateHabitFrequency, false, CreateHabitSelectedColor, DateTime.Now, CreateHabitSelectedPlant);
            this.SystemContext.SaveChanges();
            UpdateList();
        }
        private bool CanCreate(object context)
        {
            if (CreateHabitName == null || CreateHabitSelectedColor == null || CreateHabitFrequency <= 0 || CreateHabitSelectedPlant == null)
            {
                return false;
            }
            return true;
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
        public ICommand AddHabitCommand
        {
            get { return new DelegateCommand<object>(_AddHabitCommand, SureUCan); }
        }
        private void _AddHabitCommand(object param)
        {
            OpenAddWindowCommand.Execute("");
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
            this.Progress = 20;
            this.DateIsCompletedGenericService.Account = this.Account;
            UpdateList();
            ColorsList = new ObservableCollection<Color>(SystemContext.Colors);
            PLantsList = new ObservableCollection<Plant>(SystemContext.Plants);
            OnPropertyChanged(nameof(ColorsList));
            OnPropertyChanged(nameof(PLantsList));
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
        public ICommand OpenAddWindowCommand
        {
            get { return new DelegateCommand<object>(_OpenAddWindowCommand, CanChange); }
        }
        private void _OpenAddWindowCommand(object param)
        {
            ChangeWindow?.Invoke();
        }

        public bool CanChange(object context)
        {
            return true;
        }
        public Action ChangeWindow { get; set; }

        public ICommand TestCommand
        {
            get { return new DelegateCommand<object>(_TestCommand, SureUCan); }
        }
        private void _TestCommand(object param)
        {

        }
    }
}
