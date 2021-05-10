using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IHabitService<Datacontext, THabit>
    where Datacontext : class
    where THabit : class
    
    {
        void Create(Datacontext datacontext, string name, string descriprion, int progress, bool iscompleted, DateTime datecreated, int plantid);
        void Remove(Datacontext datacontext, THabit habit);
        void AddProgress(Datacontext datacontext, THabit habit);
        bool IsCompleted(Datacontext datacontext, THabit habit);
        void HabitCheker(Datacontext datacontext, THabit habit);
    }
}
