using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities
{
    public class EntityType : EntitiesBase, IEntity
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}