using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.BL.Implementation.Class;
using HealthyHabit.Models;
namespace HealthyHabit.BL.Implementation
{
    public class DateIsCompletedGeneric
    {
        /// <summary>
        /// Class for generic itemlist on main menu for RadioButton + Label area.
        /// </summary>
        public Habit Habit { get; set; }
        public List<MarkHabitUnit> FirstPartUnits { get; set; }
        public List<MarkHabitUnit> SecondPartUnits { get; set; }
        public List<MarkHabitUnit> ThirdPartUnits { get; set; }
        public List<MarkHabitUnit> CurrentPartUnits { get; set; }
        public DateIsCompletedGeneric(Habit habit)
        {
            this.Habit = habit;
        }
    }
}
