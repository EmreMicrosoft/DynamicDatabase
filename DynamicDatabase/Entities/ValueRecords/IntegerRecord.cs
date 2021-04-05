using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities.ValueRecords
{
    public class IntegerRecord : RecordsBase, IEntity
    {
        [Required]
        public int Value { get; set; }
    }
}