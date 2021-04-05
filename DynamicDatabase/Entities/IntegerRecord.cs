using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Entities
{
    public class IntegerRecord : IEntity
    {
        public int Value { get; set; }
    }
}