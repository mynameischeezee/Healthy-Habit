using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.Models;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;
using System.Linq;

namespace HealthyHabit.BL.Implementation
{
    public class AuthenticationService : IAuthenticationService<SystemContextSQL>
    {
        private ISaltService salt { get; set; }
        private IHashService hash { get; set; }
        private IUserService<SystemContextSQL, User> UserService { get; set; }
        private IAccountHolder<User> AccountHolder { get; set; }
        public AuthenticationService(ISaltService saltService, IHashService hashService, IUserService<SystemContextSQL, User> userService, IAccountHolder<User> accountHolder)
        {
            salt = saltService;
            hash = hashService;
            UserService = userService;
            AccountHolder = accountHolder;
        }
        public void Login(SystemContextSQL datacontext, string username, string password)
        {
            if (datacontext.User.Any(user => user.UserName == username))
            {
                
                var tmpUser = datacontext.User.FirstOrDefault(user => user.UserName == username);
                string a = password + tmpUser.Salt;
                string b = hash.DeHash(tmpUser.PasswordHash);
                if (hash.Hash(password + tmpUser.Salt).Equals(tmpUser.PasswordHash))
                {
                    AccountHolder.SetUser(tmpUser);
                }
                else
                {
                    throw new Exception("Wrong username or password");
                }
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void Register(SystemContextSQL datacontext, string name, string username, string mail, string password)
        {
            string saltstr = salt.Generate();
            UserService.Add(datacontext, name, username, mail, hash.Hash(password+saltstr), saltstr);
        }
    }
}
