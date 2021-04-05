using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities
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