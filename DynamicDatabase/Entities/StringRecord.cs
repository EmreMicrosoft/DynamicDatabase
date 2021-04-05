using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities
{
    public class StringRecord : IEntity
    {
        public string Value { get; set; }
    }
}