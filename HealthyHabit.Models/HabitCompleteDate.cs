using HealthyHabit.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.Models
{
    public class HabitCompleteDate : ModelTemplate
    {
        public Habit Habit { get; set; }
        public int? HabitId { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}
