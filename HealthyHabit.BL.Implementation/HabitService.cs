using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.Models;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;

namespace HealthyHabit.BL.Implementation
{
    public class HabitService : IHabitService<SystemContextSQL, Habit, Color, Plant>
    {
        public void AddProgress(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, string desciption, int progress, bool iscompleted, Color color, DateTime datecreated, Plant plant)
        {
            throw new NotImplementedException();
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
