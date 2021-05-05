using HealthyHabit.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.Models
{
    public class User : ModelTemplate
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public User()
        {

        }

    }
}
