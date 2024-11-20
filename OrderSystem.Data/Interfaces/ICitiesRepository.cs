using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICitiesRepository
    {
        void Delete(int cityId, SqlConnection conn, SqlTransaction tran);
        bool IsRelated(int cityId, SqlConnection conn, SqlTransaction? tran = null);
        void Add(City city, SqlConnection conn, SqlTransaction tran);
        void Edit(City city, SqlConnection conn, SqlTransaction tran);
        bool Exist(City city, SqlConnection conn, SqlTransaction? tran = null);
        List<CityListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null);
        City? GetCityById(int cityId, SqlConnection conn);
        List<City> GetListCombo(SqlConnection conn, Country selectedCountry, StateProvince stateProvince);
        int GetCount(SqlConnection conn, Country? selectedCountry, StateProvince? selectedStateProvince, SqlTransaction? tran = null);
        int GetPageByRecord(SqlConnection conn, string cityName, int pageSize, SqlTransaction? tran = null);
    }
}
