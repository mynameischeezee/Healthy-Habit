using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.Models;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;

namespace HealthyHabit.BL.Implementation
{
    public class HabitService : IHabitService<SystemContextSQL, Habit>
    {
        public void AddProgress(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, string name, string descriprion, int progress, bool iscompleted, DateTime datecreated, int plantid)
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
