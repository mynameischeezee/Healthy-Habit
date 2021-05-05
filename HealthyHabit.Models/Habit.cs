using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.DAL.Abstract;

namespace HealthyHabit.Models
{
    public class Habit : ModelTemplate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int  Progress { get; set; }
        public bool IsCompleted { get; set; }
        public string Color { get; set; }
        public DateTime DateCreated { get; set; }
        public int PlantId { get; set; }
    }
}
