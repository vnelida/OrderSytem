using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; } = null!;
        public string BuildingNumber { get; set; } = null!;
        public string? BetweenStreet1 { get; set; }
        public string? BetweenStreet2 { get; set; }
        public int? FloorNumber { get; set; }
        public string? ApartmentUnit { get; set; }

        public int CountryId { get; set; }
        public int StateProvinceId { get; set; }
        public int CityId { get; set; }
        public string CodePostal { get; set; } = null!;
        public Country? Country { get; set; }
        public StateProvince? StateProvince { get; set; }
        public City? City { get; set; }
    }
}
