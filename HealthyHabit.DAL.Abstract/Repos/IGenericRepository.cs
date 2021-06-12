﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.DAL.Abstract
{

    public interface IGenericRepository<EntityTemplate>
    where EntityTemplate : class
    {
        IEnumerable<EntityTemplate> GetAll();
        EntityTemplate Get(int id);
        EntityTemplate Create(EntityTemplate entity);
        EntityTemplate Update(int id, EntityTemplate entity);
        bool Delete(int id);
    }
}
