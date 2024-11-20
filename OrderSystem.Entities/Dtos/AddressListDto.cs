using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AddressListDto
    {
        public int AddressId { get; set; }
        public string? AddressType { get; set; }
        public string Street { get; set; } = null!;
        public string BuildingNumber { get; set; } = null!;
        public string? BetweenStreet1 { get; set; }
        public string? BetweenStreet2 { get; set; }

        public string? Country { get; set; }
        public string? StateProvince { get; set; }
        public string? City { get; set; }
        public string PostalCode { get; set; } = null!;
        public override string ToString()
        {
            return $"{Street} {BuildingNumber} - {City} - {StateProvince} - {Country}";
        }
    }
}
