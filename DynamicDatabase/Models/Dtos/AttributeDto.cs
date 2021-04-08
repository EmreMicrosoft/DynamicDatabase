namespace DynamicDatabase.Models.Dtos
{
    public class AttributeDto
    {
        public int Id { get; set; }
        public string EntityTypeName { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}