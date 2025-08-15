namespace Entities.Entities
{
    public class ComboDetail
    {
        public int ComboDetailId { get; set; }
        public int ProductId { get; set; }
        public int ComboId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
        public Combo? Combo { get; set; }

    }
}
