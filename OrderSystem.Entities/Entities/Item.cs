namespace Entities.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int OnOrderQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool Suspended { get; set; }
        public string? Image { get; set; }
    }
}
