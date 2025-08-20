namespace Entities.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public List<SaleDetail> Details { get; set; } = new List<SaleDetail>();
        public Customer? Customer { get; set; } 
        public OrderType? OrderType { get; set; } 
        public OrderStatus? OrderStatus { get; set; } 

        public void Add(SaleDetail details)
        {
            var dEnVenta = Details.FirstOrDefault(
                x => x.ProductId == details.ProductId && x.ComboId == details.ComboId);
            if (dEnVenta == null)
            {
                Details.Add(details);
            }
            else
            {
                dEnVenta.Quantity += details.Quantity;
            }
        }
        public decimal GetTotal() => Details.Sum(dv => dv.Quantity * dv.Price);
        public int GetQuantity() => Details.Sum(dv => dv.Quantity);

        public void Delete(SaleDetail dt)
        {
            Details.Remove(dt);
        }

        public List<Payment> Payments { get; set; } = new List<Payment>(); // <<<--- Nueva lista de pagos en memoria

    }
}
