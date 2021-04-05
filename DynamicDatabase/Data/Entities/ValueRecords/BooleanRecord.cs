using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities.ValueRecords
{
    public class BooleanRecord : RecordsBase, IEntity
    {
        [Required]
        public bool Value { get; set; }
    }
}