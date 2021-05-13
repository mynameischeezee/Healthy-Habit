using HealthyHabit.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.Models
{
    public class UserHabit : ModelTemplate
    {
        public User User { get; set; }
        public int? UserId { get; set; }
        public Habit Habit { get; set; }
        public int? HabitId { get; set; }
        public UserHabit()
        {

        }
        public UserHabit(User user, Habit habit)
        {
            this.User = user;
            this.Habit = habit;
        }
    }
}
