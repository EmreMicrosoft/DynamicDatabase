using System.ComponentModel.DataAnnotations;

namespace DynamicDatabase.Entities.Base
{
    public class RecordsBase : EntitiesBase
    {
        [Required]
        public int EntityTypeId { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        public int AttributeId { get; set; }
    }
}