using System.ComponentModel.DataAnnotations;

namespace DynamicDatabase.Data.Entities.Base
{
    public class EntitiesBase
    {
        [Key] public int Id { get; set; }
    }
}