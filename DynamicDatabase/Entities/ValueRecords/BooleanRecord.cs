using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities.ValueRecords
{
    public class BooleanRecord : RecordsBase, IEntity
    {
        [Required]
        public bool Value { get; set; }
    }
}