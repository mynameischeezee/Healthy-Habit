using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IAccountHolder<User>
    where User : class
    {
        void SetUser(User user);
        User GetUser();

    }
}
