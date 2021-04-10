using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities
{
    public class EntityType : EntityBase, IEntity
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}