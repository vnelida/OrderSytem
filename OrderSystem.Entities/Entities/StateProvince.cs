namespace Entities.Entities
{
    public class StateProvince
    {
        public int StateProvinceId { get; set; }
        public string StateProvinceName { get; set; } = null!;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
