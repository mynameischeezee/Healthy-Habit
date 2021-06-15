using System.Collections.Generic;

namespace HealthyHabit.BL.Abstract
{
    public interface IUserHabitService<Datacontext, TUser, THabit>
    where Datacontext : class
    where TUser : class
    where THabit : class
    {
        List<THabit> GetHabitsByUser(Datacontext datacontext, TUser user);
        void Remove(Datacontext datacontext, THabit habit);
    }
}
