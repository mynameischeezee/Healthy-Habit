using HealthyHabit.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.ViewModel
{
    public class MainViewModel
    {
        public DbContext SystemContext;
        public MainViewModel()
        {

        }
    }
}
