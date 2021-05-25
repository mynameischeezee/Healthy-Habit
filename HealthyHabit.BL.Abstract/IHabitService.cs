using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IHabitService<Datacontext, THabit, TColor, TPlant>
    where Datacontext : class
    where THabit : class
    where TColor : class
    where TPlant : class

    {
        void Create(Datacontext datacontext, string desciption, int progress, bool iscompleted, TColor color, DateTime datecreated, TPlant plant);
        void Remove(Datacontext datacontext, THabit habit);
        void AddProgress(Datacontext datacontext, THabit habit);
        bool IsCompleted(Datacontext datacontext, THabit habit);
        void HabitCheker(Datacontext datacontext, THabit habit);
    }
}
