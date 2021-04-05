using System;
using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities.ValueRecords
{
    public class DateTimeRecord : RecordsBase, IEntity
    {
        [Required]
        public DateTime Value { get; set; }
    }
}