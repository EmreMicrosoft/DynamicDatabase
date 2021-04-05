using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities.ValueRecords
{
    public class StringRecord : RecordsBase, IEntity
    {
        [Required]
        [StringLength(2048)]
        public string Value { get; set; }
    }
}