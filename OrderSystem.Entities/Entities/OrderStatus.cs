namespace Entities.Entities
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
