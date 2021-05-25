using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IPlantService <Datacontext, TPlant>
    where Datacontext : class
    where TPlant : class
    {
        void Create(Datacontext datacontext, string Path, string PlantName);
        void Remove(Datacontext datacontext, TPlant Plant);
        void Change(Datacontext datacontext, string Path, string PlantName);
    }
}
