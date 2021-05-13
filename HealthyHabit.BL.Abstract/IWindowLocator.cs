using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IWindowLocator
    {
        Action ChangeWindow { get; set; }
        bool CanChange(object context);
    }
}
