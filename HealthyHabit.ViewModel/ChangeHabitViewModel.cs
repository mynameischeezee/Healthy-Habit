using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace HealthyHabit.ViewModel
{
    public class ChangeHabitViewModel : ViewModelBase
    {
        public SystemContextSQL SystemContext { get; private set; }
        public IAccountHolder<User> Account { get; private set; }
        public IHabitService<SystemContextSQL, User, Habit, Color, Plant> HabitService { get; private set; }
        public IUserHabitService<SystemContextSQL, User, Habit> UserHabitService { get; private set; }
        public ChangeHabitViewModel(SystemContextSQL context, IAccountHolder<User> account, IHabitService<SystemContextSQL, User, Habit, Color, Plant> habitService, IUserHabitService<SystemContextSQL, User, Habit> userHabitService)
        {
            this.SystemContext = context;
            this.Account = account;
            this.HabitService = habitService;
        }
        public ObservableCollection<Color> ColorsList { get; private set; }
        public ObservableCollection<Plant> PLantsList { get; private set; }
        public ObservableCollection<DateIsCompletedGeneric> HabitsList { get; private set; }
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
        public string Date { get => $"{DateTime.Now.ToString("dddd", new CultureInfo("uk-UA"))}, {DateTime.Now.ToString("M", new CultureInfo("uk-UA"))} "; }
        public ICommand ChangeHabit => new DelegateCommand<object>(_ChangeHabit, CanChange);

        private void _ChangeHabit(object param)
        {
            this.HabitService.Change(SystemContext, Account.GetUser(), CreateHabitName, CreateHabitDescription, 0, CreateHabitFrequency, false, CreateHabitSelectedColor, DateTime.Now, CreateHabitSelectedPlant);
        }
        private bool CanChange(object context)
        {
            if (CreateHabitName == null || CreateHabitSelectedColor == null || CreateHabitFrequency <= 0 || CreateHabitSelectedPlant == null)
            {
                return false;
            }
            return true;
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
            ColorsList = new ObservableCollection<Color>(SystemContext.Colors);
            PLantsList = new ObservableCollection<Plant>(SystemContext.Plants);
            OnPropertyChanged(nameof(ColorsList));
            OnPropertyChanged(nameof(PLantsList));
        }
    }
}
