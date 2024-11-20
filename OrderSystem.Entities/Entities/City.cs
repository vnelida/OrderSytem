namespace Entities.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int CountryId { get; set; }
        public int StateProvinceId { get; set; }
        public Country? Country { get; set; }
        public StateProvince? StateProvince { get; set; }
    }
}
