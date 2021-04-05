using System.ComponentModel.DataAnnotations;

namespace DynamicDatabase.Entities.Base
{
    public class EntitiesBase
    {
        [Key]
        public int Id { get; set; }
    }
}