namespace Entities.Entities
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? ComboId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product? Product { get; set; }
        public Combo? Combo { get; set; }
    }
}
