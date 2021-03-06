using System.ComponentModel.DataAnnotations;

namespace DynamicDatabase.Data.Entities.Base
{
    public class EntityBase
    {
        [Key] public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}