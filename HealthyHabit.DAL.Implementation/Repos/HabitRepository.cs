using HealthyHabit.DAL.Abstract;
using HealthyHabit.Models;
using System;
using System.Collections.Generic;

namespace HealthyHabit.DAL.Implementation.Repos
{
    public class HabitRepository : IHabitRepository
    {
        public Habit Create(Habit entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Habit Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Habit> GetAll()
        {
            throw new NotImplementedException();
        }

        public Habit Update(int id, Habit entity)
        {
            throw new NotImplementedException();
        }
    }
}
