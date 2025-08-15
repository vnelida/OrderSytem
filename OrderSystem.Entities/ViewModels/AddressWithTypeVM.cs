using Entities.Entities;

namespace Entities.ViewModels
{
    public class AddressWithTypeVM
    {
        public int CustomerAddressId { get; set; } 
        public int AddressId { get; set; }
        public string Street { get; set; } = null!;
        public string BuildingNumber { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string BetweenStreet1 { get; set; } = null!;
        public string BetweenStreet2 { get; set; } = null!;
        public string StateProvinceName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string AddressTypeDescription { get; set; } = null!;
        public CustomerAddress CustomerAddressEntity { get; set; } = null!;

        public AddressWithTypeVM(CustomerAddress entity)
        {
            CustomerAddressEntity = entity; 
            AddressId = entity.Address?.AddressId ?? 0;
            Street = entity.Address?.Street ?? string.Empty;
            BuildingNumber = entity.Address?.BuildingNumber ?? string.Empty;
            CityName = entity.Address?.City?.CityName ?? "N/A";
            PostalCode = entity.Address?.PostalCode ?? "N/A";
            StateProvinceName = entity.Address?.StateProvince?.StateProvinceName ?? "N/A";
            CountryName = entity.Address?.Country?.CountryName ?? "N/A";
            AddressTypeDescription = entity.AddressType?.Description ?? "N/A";
        }        
    }
}
