using HealthyHabit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.DAL.Implementation
{
    public class SystemContextSQLite : DbContext
    {
        private readonly string ConnectionString;
        public DbSet<Habit> Habit { get; set; }
        public DbSet<HabitCompleteDate> HabitCompleteDate { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserHabit> UserHabit { get; set; }
        public SystemContextSQLite(string connectionString)
        {
            Console.WriteLine("Using SQLiteServerDB");
            this.ConnectionString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.ConnectionString);
        }


    }
}
