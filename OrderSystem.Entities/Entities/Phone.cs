namespace Entities.Entities
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        //
        public PhoneType PhoneType { get; set; }=null!;
        //
        public List<CustomerPhone> CustomerPhones { get; set; } = new List<CustomerPhone>();
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Phone other = (Phone)obj;

            if (this.PhoneId != 0 && other.PhoneId != 0)
            {
                return this.PhoneId == other.PhoneId;
            }
            // Para Phone, si es nuevo, el PhoneNumber y el PhoneType son claves para la unicidad
            return PhoneNumber == other.PhoneNumber &&
                   (PhoneType?.PhoneTypeId ?? 0) == (other.PhoneType?.PhoneTypeId ?? 0);
        }

        public override int GetHashCode()
        {
            if (PhoneId != 0)
            {
                return PhoneId.GetHashCode();
            }
            return HashCode.Combine(PhoneNumber, PhoneType?.PhoneTypeId ?? 0);
        }

        // --- Tu ToString() va aquí ---
        public override string ToString()
        {
            // Como lo habíamos ajustado para mostrar número y tipo.
            return $"{PhoneNumber ?? "N/A"} ({PhoneType?.Description ?? "Tipo N/A"})";
        }
    }
}
