using HealthyHabit.BL.Abstract;
using HealthyHabit.Models;

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
