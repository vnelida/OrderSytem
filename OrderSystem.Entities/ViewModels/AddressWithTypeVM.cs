using Entities.Entities;

namespace Entities.ViewModels
{
    public class AddressWithTypeVM
    {
        public Address Address { get; set; }
        public AddressType? AddressType { get; set; }

        public AddressWithTypeVM(Address address, AddressType? addressType)
        {
            Address = address;
            AddressType = addressType;
        }

        public override string ToString()
        {
            return $"{Address.Street} {Address.BuildingNumber}, {Address.City?.CityName}, {AddressType.Description}";
        }
    }
}
