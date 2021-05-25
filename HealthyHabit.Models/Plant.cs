using System;
using System.Collections.Generic;
using System.Text;
using HealthyHabit.DAL.Abstract;

namespace HealthyHabit.Models
{
    public class Plant : ModelTemplate
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Plant(string path, string name)
        {
            this.Path = path;
            this.Name = name;
        }
    }
}
