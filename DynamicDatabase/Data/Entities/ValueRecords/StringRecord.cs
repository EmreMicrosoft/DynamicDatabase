using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities.ValueRecords
{
    public class StringRecord : RecordsBase, IEntity
    {
        [Required]
        [StringLength(2048)]
        public string Value { get; set; }
    }
}