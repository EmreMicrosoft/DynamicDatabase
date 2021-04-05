using System;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities
{
    public class DateTimeRecord : IEntity
    {
        public DateTime Value { get; set; }
    }
}