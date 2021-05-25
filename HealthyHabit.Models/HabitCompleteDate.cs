using HealthyHabit.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthyHabit.Models
{
    public class HabitCompleteDate : ModelTemplate
    {
        [ForeignKey(nameof(HabitId))]
        public Habit Habit { get; set; }
        public int? HabitId { get; set; }
        public DateTime CompleteDate { get; set; }
        public HabitCompleteDate()
        {
                
        }
        public HabitCompleteDate(Habit habit, DateTime completeDate)
        {
            this.Habit = habit;
            this.CompleteDate = completeDate;
        }
        public HabitCompleteDate(Habit habit, int Id, DateTime completeDate)
        {
            this.Habit = habit;
            this.HabitId = Id;
            this.CompleteDate = completeDate;
        }
    }
}
