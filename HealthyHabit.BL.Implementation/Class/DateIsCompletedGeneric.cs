using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation.Class;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.VisualStudio.PlatformUI;
using System.Collections.Generic;
using System.Windows.Input;

namespace HealthyHabit.BL.Implementation
{
    public class DateIsCompletedGeneric
    {
        /// <summary>
        /// Class for generic itemlist on main menu for RadioButton + Label area.
        /// </summary>
        /// 
        public SystemContextSQL systemContext { get; set; }
        public IHabitService<SystemContextSQL, User, Habit, Color, Plant> HabitService { get; set; }
        public IUserHabitService<SystemContextSQL, User, Habit> UserHabitService { get; set; }
        public Habit Habit { get; set; }
        public List<MarkHabitUnit> FirstPartUnits { get; set; }
        public List<MarkHabitUnit> SecondPartUnits { get; set; }
        public List<MarkHabitUnit> ThirdPartUnits { get; set; }
        public List<MarkHabitUnit> CurrentPartUnits { get; set; }
        public DateIsCompletedGeneric(Habit habit, SystemContextSQL systemContext, IHabitService<SystemContextSQL, User, Habit, Color, Plant> habitService, IUserHabitService<SystemContextSQL, User, Habit> UserHabitService)
        {
            this.Habit = habit;
            this.systemContext = systemContext;
            this.HabitService = habitService;
            this.UserHabitService = UserHabitService;
        }
        public ICommand DeleteHabit
        {
            get { return new DelegateCommand<object>(_DeleteHabit, SureUCan); }
        }
        private void _DeleteHabit(object param)
        {
            this.UserHabitService.Remove(systemContext, (Habit)param);
            HabitService.Remove(systemContext, (Habit)param);
        }
        private bool SureUCan(object context)
        {
            return true;
        }
    }
}
