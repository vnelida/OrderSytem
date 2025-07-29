namespace Entities.Entities
{
    public class CustomerAddress
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }

      
        public Customer Customer { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public AddressType AddressType { get; set; } = null!;
    }
}
