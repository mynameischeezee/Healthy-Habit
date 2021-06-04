using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHabit.BL.Implementation
{
    public class UserHabitService : IUserHabitService<SystemContextSQL, User, Habit>
    {
        public List<Habit> GetHabitsByUser(SystemContextSQL datacontext, User user)
        {
            List<Habit> habits = new List<Habit>();
            var habitsID = datacontext.UserHabit.Include(u => u.User).Include(h => h.Habit).Where(uh => uh.User == user);
            foreach (UserHabit habit in habitsID)
            {
                habits.Add(habit.Habit);
            }
            return habits;
        }
    }
}
