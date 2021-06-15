using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using System;

namespace HealthyHabit.BL.Implementation
{
    public class PlantService : IPlantService<SystemContextSQL, Plant>
    {
        public void Change(SystemContextSQL datacontext, string previewpath, string stage0path, string stage1path, string stage2path, string stage3path, string stage4path, string stage5path, string stage6path, string stage7path, string name)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, string previewpath, string stage0path, string stage1path, string stage2path, string stage3path, string stage4path, string stage5path, string stage6path, string stage7path, string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(SystemContextSQL datacontext, Plant Plant)
        {
            throw new NotImplementedException();
        }
    }
}
