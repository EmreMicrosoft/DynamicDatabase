using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities.ValueRecords
{
    public class DecimalRecord : RecordsBase, IEntity
    {
        [Required]
        public decimal Value { get; set; }
    }
}