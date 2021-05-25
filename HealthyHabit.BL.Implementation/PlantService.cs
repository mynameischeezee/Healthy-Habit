using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Implementation
{
    public class PlantService : IPlantService<SystemContextSQL, Plant>
    {
        public void Change(SystemContextSQL datacontext, string Path, string PlantName)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, string Path, string PlantName)
        {
            throw new NotImplementedException();
        }

        public void Remove(SystemContextSQL datacontext, Plant Plant)
        {
            throw new NotImplementedException();
        }
    }
}
