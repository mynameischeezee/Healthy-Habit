using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyHabit.Models
{
    public class Habit : ModelTemplate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public int Frequency { get; set; }
        public bool IsCompleted { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey(nameof(PlantId))]
        public Plant Plant { get; set; }
        public int PlantId { get; set; }
        public string CurrentStagePath { get; set; }
        public Habit()
        {

        }
        public Habit(string name, string desciption, int progress, int frequency, bool iscompleted, Color color, DateTime datecreated, Plant plant, string currentStagePath)
        {
            this.Name = name;
            this.Description = desciption;
            this.Progress = progress;
            this.Frequency = frequency;
            this.IsCompleted = iscompleted;
            this.Color = color;
            this.DateCreated = datecreated;
            this.Plant = plant;
            this.CurrentStagePath = currentStagePath;
        }
    }
}
