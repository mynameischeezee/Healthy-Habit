using HealthyHabit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.DAL.Implementation
{
    public class SystemContextSQL : DbContext
    {
        public DbSet<Habit> Habit { get; set; }
        public DbSet<HabitCompleteDate> HabitCompleteDate { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserHabit> UserHabit { get; set; }
        public SystemContextSQL(DbContextOptions<SystemContextSQL> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
