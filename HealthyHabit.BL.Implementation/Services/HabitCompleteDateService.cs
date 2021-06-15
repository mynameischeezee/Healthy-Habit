using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthyHabit.BL.Implementation
{
    public class HabitCompleteDateService : IHabitCompleteDateService<SystemContextSQL, Habit, HabitCompleteDate>
    {
        public void AddProgress(SystemContextSQL datacontext, Habit habit)
        {
            if (habit.Progress <= 21 && habit.IsCompleted == false)
            {
                habit.Progress += 1;
                if (habit.Progress == 21)
                {
                    habit.IsCompleted = true;
                }
                datacontext.HabitCompleteDate.Add(new HabitCompleteDate(habit));
            }
            datacontext.SaveChanges();
        }

        public void AddProgress(SystemContextSQL datacontext, Habit habit, DateTime date)
        {
            if (habit.Progress <= 21 && habit.IsCompleted == false)
            {
                habit.Progress += 1;
                if (habit.Progress == 21)
                {
                    habit.IsCompleted = true;
                }
                datacontext.HabitCompleteDate.Add(new HabitCompleteDate(habit, date));
            }
            datacontext.SaveChanges();
        }

        public List<HabitCompleteDate> GetAllForHabit(SystemContextSQL datacontext, Habit habit)
        {
            List<HabitCompleteDate> habits = new List<HabitCompleteDate>();
            var habitsID = datacontext.HabitCompleteDate.Include(h => h.Habit).Where(x => x.HabitId == habit.ID);
            foreach (HabitCompleteDate competehabits in habitsID)
            {
                habits.Add(competehabits);
            }
            return habits;
        }

        public void Remove(SystemContextSQL datacontext, HabitCompleteDate habit)
        {
            datacontext.HabitCompleteDate.Remove(habit);
            datacontext.SaveChanges();
        }
    }
}
