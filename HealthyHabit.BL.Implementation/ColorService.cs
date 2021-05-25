using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Implementation
{
    public class ColorService : IColorService<SystemContextSQL, Color>
    {
        public void Change(SystemContextSQL datacontext, string HexCode, string ColorName)
        {
            throw new NotImplementedException();
        }

        public void Create(SystemContextSQL datacontext, string HexCode, string ColorName)
        {
            throw new NotImplementedException();
        }

        public void Remove(SystemContextSQL datacontext, Color habit)
        {
            throw new NotImplementedException();
        }
    }
}
