using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.Models;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;

namespace HealthyHabit.BL.Implementation
{
    public class AccountHolder : IAccountHolder<User>
    {
        private User Account { get; set; }
        public AccountHolder()
        {
        }
        public void SetUser(User user)
        {
            this.Account = user; 
        }

        public User GetUser()
        {
            return this.Account;
        }
    }
}
