namespace Entities.Dtos
{
    public class PaymentReportDto
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal CashAmount { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal CardAmount { get; set; }
        public decimal CouponAmount { get; set; }
    }
}
