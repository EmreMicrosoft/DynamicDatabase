using System.Collections.Generic;
using DynamicDatabase.Data.Entities;

namespace DynamicDatabase.Models.ViewModels
{
    public class AttributeViewModel
    {
        public Attribute Attribute { get; set; }
        public IList<EntityType> EntityTypes { get; set; }

        public int SelectedEntityTypeId { get; set; }
    }
}