namespace Entities.Entities
{
    public class OrderType
    {
        public int OrderTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public List<Sale> Sales { get; set; } = new List<Sale>();

    }
}
