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

        public AddressType? AddressType { get; set; }
        public override string ToString()
        {
            return $"{Street ?? ""} {BuildingNumber ?? ""}" +
               $"{(!string.IsNullOrEmpty(Street) || !string.IsNullOrEmpty(BuildingNumber) ? ", " : "")}" +
               $"{City?.CityName ?? ""}" +
               $"{((City != null || StateProvince != null) && StateProvince != null ? ", " : "")}{StateProvince?.StateProvinceName ?? ""}" +
               $"{((StateProvince != null || Country != null) && Country != null ? ", " : "")}{Country?.CountryName ?? ""}" +
               $"{((!string.IsNullOrEmpty(PostalCode) && (City != null || StateProvince != null || Country != null)) ? " - CP: " : "")}{PostalCode ?? ""}" +
               $" ({AddressType?.Description ?? "Tipo N/A"})";
        }


        public override bool Equals(object? obj)
        {
            // 1. Verificar si el objeto es nulo o de un tipo diferente
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Address other = (Address)obj; // Castear al tipo correcto

            // 2. Comparar por la clave primaria (AddressId) si el objeto ya ha sido guardado
            if (this.AddressId != 0 && other.AddressId != 0)
            {
                return this.AddressId == other.AddressId;
            }

            // 3. Si ambos objetos son nuevos (AddressId es 0), comparar por sus propiedades de negocio clave.
            // Esto es crucial para identificar duplicados antes de guardar en la DB.
            return Street == other.Street &&
                   BuildingNumber == other.BuildingNumber &&
                   (PostalCode == other.PostalCode) && // Asegura que se compara el PostalCode
                   (CityId == other.CityId) &&         // Compara por los IDs de FK
                   (StateProvinceId == other.StateProvinceId) &&
                   (CountryId == other.CountryId) &&
                   // Si AddressType es importante para la unicidad de una nueva Address
                   (AddressType?.AddressTypeId ?? 0) == (other.AddressType?.AddressTypeId ?? 0);
        }

        public override int GetHashCode()
        {
            // El HashCode debe ser consistente con Equals.
            // Si el ID es 0, usa una combinación de propiedades para el hash.
            if (AddressId != 0)
            {
                return AddressId.GetHashCode(); // Si tiene ID, usa el ID
            }
            // Si no tiene ID (es nuevo), usa una combinación de propiedades de negocio.
            // HashCode.Combine es un helper de .NET 6+
            return HashCode.Combine(Street, BuildingNumber, PostalCode, CityId, StateProvinceId, CountryId, AddressType?.AddressTypeId ?? 0);
        }

    }
}
