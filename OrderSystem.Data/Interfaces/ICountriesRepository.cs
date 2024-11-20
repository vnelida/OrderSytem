using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountriesRepository
    {
        int GetCount(SqlConnection conn, SqlTransaction? tran = null);
        void Add(Country country, SqlConnection conn, SqlTransaction? tran = null);
        void Delete(int paisId, SqlConnection conn, SqlTransaction? tran = null);
        void Edit(Country country, SqlConnection conn, SqlTransaction? tran = null);
        bool IsRelated(int typeId, SqlConnection conn, SqlTransaction? tran = null);
        bool Exist(Country country, SqlConnection conn, SqlTransaction? tran = null);
        List<Country>? GetList(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null);
        Country? GetCountryById(int countryId, SqlConnection conn, SqlTransaction? tran = null);
        int GetPageByRecord(SqlConnection conn, string countryName, int totalPages);
    }
}
