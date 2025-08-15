namespace Entities.Entities
{
    public class CustomerPhone
    {
        public int CustomerId { get; set; }
        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }
        public Phone Phone { get; set; } = null!;
        public PhoneType PhoneType { get; set; } = null!;
    }
}
