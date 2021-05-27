using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IUserHabitService<Datacontext, TUser, THabit>
    where Datacontext : class
    where TUser : class
    where THabit : class
    {
         List<THabit> GetHabitsByUser(Datacontext datacontext, TUser user);
    }
}
