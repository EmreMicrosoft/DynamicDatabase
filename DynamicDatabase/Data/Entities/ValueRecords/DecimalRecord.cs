using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities.ValueRecords
{
    public class DecimalRecord : RecordsBase, IEntity
    {
        [Required]
        public decimal Value { get; set; }
    }
}