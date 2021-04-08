using System.Collections.Generic;
using DynamicDatabase.Data.Entities;

namespace DynamicDatabase.Models.ViewModels
{
    public class EntityViewModel
    {
        public IEnumerable<EntityType> EntityTypes { get; set; }
        public EntityType EntityType { get; set; }
    }
}