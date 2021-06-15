using System;
using System.Collections.Generic;

namespace HealthyHabit.BL.Abstract
{
    public interface IHabitCompleteDateService<Datacontext, THabit, THabitCompleteDate>
    where Datacontext : class
    where THabit : class
    where THabitCompleteDate : class
    {
        void Remove(Datacontext datacontext, THabitCompleteDate date);
        void AddProgress(Datacontext datacontext, THabit habit);
        void AddProgress(Datacontext datacontext, THabit habit, DateTime date);
        List<THabitCompleteDate> GetAllForHabit(Datacontext datacontext, THabit habit);
    }
}
