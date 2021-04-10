using System.ComponentModel.DataAnnotations;

namespace DynamicDatabase.Data.Entities.Base
{
    public class RecordsBase : EntityBase
    {
        [Required]
        public int EntityTypeId { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        public int AttributeId { get; set; }
    }
}