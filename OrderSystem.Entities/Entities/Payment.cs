namespace Entities.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int SaleId { get; set; }

        public int PaymentMethodID { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
