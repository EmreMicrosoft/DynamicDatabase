﻿using System.Collections.Generic;
using DynamicDatabase.Data.Entities;

namespace DynamicDatabase.Models
{
    public class HomeViewModel
    {
        public IList<EntityType> EntityTypes { get; set; }
    }
}