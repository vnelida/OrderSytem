using Entities.Entities;

namespace Services.Interfaces
{
    public interface ICountriesService
    {
        void Delete(int countryId);
        bool IsRelated(int countryId);
        bool Exist(Country country);
        List<Country>? GetList(int? currentPage, int? pageSize);
        void Save(Country country);
        Country? GetCountryById(int countryId);
        int GetCount();
        int GetPageByRecord(string countryName, int pageSize);
    }
}
