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
        public string PostalCode { get; set; } = null!;
        public Country? Country { get; set; }
        public StateProvince? StateProvince { get; set; }
        public City? City { get; set; }

        public override string ToString()
        {
            return $"{Street ?? ""} {BuildingNumber ?? ""}" +
               $"{(!string.IsNullOrEmpty(Street) || !string.IsNullOrEmpty(BuildingNumber) ? ", " : "")}" +
               $"{City?.CityName ?? ""}" +
               $"{((City != null || StateProvince != null) && StateProvince != null ? ", " : "")}{StateProvince?.StateProvinceName ?? ""}" +
               $"{((StateProvince != null || Country != null) && Country != null ? ", " : "")}{Country?.CountryName ?? ""}" +
               $"{((!string.IsNullOrEmpty(PostalCode) && (City != null || StateProvince != null || Country != null)) ? " - CP: " : "")}{PostalCode ?? ""}";
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Address other = (Address)obj;

            if (this.AddressId != 0 && other.AddressId != 0) { return this.AddressId == other.AddressId; }

            return Street == other.Street &&
                   BuildingNumber == other.BuildingNumber &&
                   PostalCode == other.PostalCode &&
                   CityId == other.CityId &&
                   StateProvinceId == other.StateProvinceId &&
                   CountryId == other.CountryId
                   ;
        }

        public override int GetHashCode()
        {
            if (AddressId != 0) { return AddressId.GetHashCode(); }
            return HashCode.Combine(Street, BuildingNumber, PostalCode, CityId, StateProvinceId, CountryId);
        }

    }
}
