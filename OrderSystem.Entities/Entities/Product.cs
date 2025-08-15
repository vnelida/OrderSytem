namespace Entities.Entities
{
    public class Product : Item
    {
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
