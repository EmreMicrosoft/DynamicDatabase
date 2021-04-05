using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities
{
    public class DecimalRecord : IEntity
    {
        public decimal Value { get; set; }
    }
}