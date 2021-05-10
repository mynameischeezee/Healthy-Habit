using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IUserService<Datacontext, TUser>
    where Datacontext : class
    where TUser : class
    {
        void Add(Datacontext datacontext, string name, string username, string mail, string passwordhash, string salt);
        void Remove(Datacontext datacontext, TUser user);
        void Change(Datacontext datacontext, string name, string username, string mail, string password);
        bool IsExists(Datacontext datacontext, string username);
        bool IsExists(Datacontext datacontext, TUser user);
    }
}
