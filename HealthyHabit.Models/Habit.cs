using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey(nameof(PlantId))]
        public Plant Plant { get; set; }
        public int PlantId { get; set; }
        public Habit()
        {

        }
        public Habit(string name, string desciption, int progress, bool iscompleted, Color color, DateTime datecreated, Plant plant)
        {
            this.Name = name;
            this.Description = desciption;
            this.Progress = progress;
            this.IsCompleted = iscompleted;
            this.Color = color;
            this.DateCreated = datecreated;
            this.Plant = plant;
        }
    }
}
