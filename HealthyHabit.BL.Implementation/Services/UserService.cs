using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using System;
using System.Linq;

namespace HealthyHabit.BL.Implementation
{
    public class UserService : IUserService<SystemContextSQL, User>
    {
        public void Add(SystemContextSQL datacontext, string name, string username, string mail, string passwordhash, string salt)
        {
            if (!IsExists(datacontext, username))
            {
                datacontext.User.Add(new User(name, username, mail, passwordhash, salt));
                datacontext.SaveChanges();
            }
            else
            {
                throw new Exception("User is already exists");
            }
        }

        public void Change(SystemContextSQL datacontext, string name, string username, string mail, string password)
        {
            User tmpUser = datacontext.User.FirstOrDefault(user => user.UserName == username);
            tmpUser.Name = name;
            tmpUser.UserName = username;
            tmpUser.Mail = mail;
            datacontext.SaveChanges();
        }

        public bool IsExists(SystemContextSQL datacontext, string username)
        {
            return datacontext.User.Any(user => user.UserName == username);
        }

        public bool IsExists(SystemContextSQL datacontext, User user)
        {
            return datacontext.User.Any(tuser => tuser == user);
        }

        public void Remove(SystemContextSQL datacontext, User user)
        {
            datacontext.User.Remove(user);
            datacontext.SaveChanges();
        }
    }
}
