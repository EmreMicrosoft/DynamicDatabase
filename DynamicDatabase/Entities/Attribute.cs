using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities
{
    public class Attribute : EntitiesBase, IEntity
    {
        [Required]
        public int EntityTypeId { get; set; }


        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}