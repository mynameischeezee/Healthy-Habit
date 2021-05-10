using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.Models;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;

namespace HealthyHabit.BL.Implementation
{
    public class AuthenticationService : IAuthenticationService<SystemContextSQL>
    {
        public void Change(SystemContextSQL datacontext, string name, string username, string mail, string password)
        {
            throw new NotImplementedException();
        }

        public void Login(SystemContextSQL datacontext, string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(SystemContextSQL datacontext, string name, string username, string mail, string password)
        {
            throw new NotImplementedException();
        }

        public void Remove(SystemContextSQL datacontext, string username)
        {
            throw new NotImplementedException();
        }
    }
}
