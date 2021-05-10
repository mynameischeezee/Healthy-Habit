﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.BL.Abstract
{
    public interface IHashService
    {
        string Hash(string password);
        string DeHash(string hash);

    }
}
