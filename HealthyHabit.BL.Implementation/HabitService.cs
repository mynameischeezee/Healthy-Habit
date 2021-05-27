using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.Models;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;
using System.Linq;

namespace HealthyHabit.BL.Implementation
{
    public class HabitService : IHabitService<SystemContextSQL, User, Habit, Color, Plant>
    {
        public void AddProgress(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }

        public void Change(SystemContextSQL datacontext, User user, string name, string desciption, int progress, int  frequency, bool iscompleted, Color color, DateTime datecreated, Plant plant)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, User user, string name, string desciption, int progress, int frequency, bool iscompleted, Color color, DateTime datecreated, Plant plant)
        {
            datacontext.Habit.Add(new Habit(name,desciption,progress, frequency, iscompleted,color,datecreated,plant));
            datacontext.SaveChanges();
            datacontext.UserHabit.Add(new UserHabit(user, datacontext.Habit.FirstOrDefault(hh => hh.ID == datacontext.Habit.Max(h=> h.ID))));
            datacontext.SaveChanges();
        }

        public void HabitCheker(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }

        public bool IsCompleted(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }

        public void Remove(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }
    }
}
