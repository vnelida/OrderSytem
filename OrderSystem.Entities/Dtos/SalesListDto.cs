namespace Entities.Dtos
{
    public class SalesListDto
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Customer { get; set; }

        public int OrderTypeId { get; set; }
        public string? OrderType { get; set; }
        public int OrderStatusId { get; set; }
        public string? OrderStatus { get; set; } 
    }
}
