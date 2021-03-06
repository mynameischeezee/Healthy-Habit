using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public HabitCompleteDate(Habit habit)
        {
            this.Habit = habit;
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
