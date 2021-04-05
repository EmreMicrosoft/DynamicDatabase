using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities.ValueRecords
{
    public class IntegerRecord : RecordsBase, IEntity
    {
        [Required]
        public int Value { get; set; }
    }
}