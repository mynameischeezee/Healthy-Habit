using System;

namespace HealthyHabit.BL.Abstract
{
    public interface IHabitService<Datacontext, TUser, THabit, TColor, TPlant>
    where Datacontext : class
    where TUser : class
    where THabit : class
    where TColor : class
    where TPlant : class

    {
        void Create(Datacontext datacontext, TUser user, string name, string desciption, int progress, int frequency, bool iscompleted, TColor color, DateTime datecreated, TPlant plant);
        void Change(Datacontext datacontext, TUser user, string name, string desciption, int progress, int frequency, bool iscompleted, TColor color, DateTime datecreated, TPlant plant);
        void Remove(Datacontext datacontext, THabit habit);
        bool IsCompleted(Datacontext datacontext, THabit habit);
        void HabitCheker(Datacontext datacontext, THabit habit);
    }
}
