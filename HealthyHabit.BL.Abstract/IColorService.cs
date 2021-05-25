using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IColorService <Datacontext, TColor>
    where Datacontext : class
    where TColor : class
    {
        void Create(Datacontext datacontext, string HexCode, string ColorName);
        void Remove(Datacontext datacontext, TColor habit);
        void Change(Datacontext datacontext, string HexCode, string ColorName);
    }
}
