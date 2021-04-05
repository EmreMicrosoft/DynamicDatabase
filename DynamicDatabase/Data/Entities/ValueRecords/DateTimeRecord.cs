using System;
using System.ComponentModel.DataAnnotations;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Entities.ValueRecords
{
    public class DateTimeRecord : RecordsBase, IEntity
    {
        [Required]
        public DateTime Value { get; set; }
    }
}