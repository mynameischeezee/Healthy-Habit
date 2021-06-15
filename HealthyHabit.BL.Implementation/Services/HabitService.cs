using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using System;
using System.Linq;

namespace HealthyHabit.BL.Implementation
{
    public class HabitService : IHabitService<SystemContextSQL, User, Habit, Color, Plant>
    {

        public void Change(SystemContextSQL datacontext, User user, string name, string desciption, int progress, int frequency, bool iscompleted, Color color, DateTime datecreated, Plant plant)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, User user, string name, string desciption, int progress, int frequency, bool iscompleted, Color color, DateTime datecreated, Plant plant)
        {
            datacontext.Habit.Add(new Habit(name, desciption, progress, frequency, iscompleted, color, datecreated, plant, plant.Stage1Path));
            datacontext.SaveChanges();
            datacontext.UserHabit.Add(new UserHabit(user, datacontext.Habit.FirstOrDefault(hh => hh.ID == datacontext.Habit.Max(h => h.ID))));
            datacontext.SaveChanges();
        }

        public void HabitCheker(SystemContextSQL datacontext, Habit habit)
        {
            if (habit.Progress == 0)
            {
                habit.Plant.CurrentStage = habit.Plant.Stage0Path;
            }
            switch (habit.Progress / 3)
            {
                case (1):
                    habit.CurrentStagePath = habit.Plant.Stage1Path;
                    break;
                case (2):
                    habit.CurrentStagePath = habit.Plant.Stage2Path;
                    break;
                case (3):
                    habit.CurrentStagePath = habit.Plant.Stage3Path;
                    break;
                case (4):
                    habit.CurrentStagePath = habit.Plant.Stage4Path;
                    break;
                case (5):
                    habit.CurrentStagePath = habit.Plant.Stage5Path;
                    break;
                case (6):
                    habit.CurrentStagePath = habit.Plant.Stage6Path;
                    break;
                case (7):
                    habit.CurrentStagePath = habit.Plant.Stage7Path;
                    break;
            }
        }

        public bool IsCompleted(SystemContextSQL datacontext, Habit habit)
        {
            throw new NotImplementedException();
        }

        public void Remove(SystemContextSQL datacontext, Habit habit)
        {
            datacontext.Habit.Remove(habit);
            datacontext.SaveChanges();
        }
    }
}
