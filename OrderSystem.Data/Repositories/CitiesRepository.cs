using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        public void Add(City city, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Cities 
                (CityName, CountryId, StateProvinceId) 
                VALUES (@CityName, @CountryId, @StateProvinceId); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, city, tran);
            if (primaryKey > 0)
            {
                city.CityId = primaryKey;
                return;
            }
            throw new Exception("City could not be added.");
        }

        public void Delete(int cityId, SqlConnection conn, SqlTransaction tran)
        {
            var deleteQuery = @"DELETE FROM Cities WHERE CityId=@CityId";
            int registrosAfectados = conn.Execute(deleteQuery, new { cityId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("City could not be deleted.");
            }
        }

        public void Edit(City city, SqlConnection conn, SqlTransaction tran)
        {
            var updateQuery = @"UPDATE Cities
            SET CityName=@CityName,
                CountryId=@CountryId,
                StateProvinceId=@StateProvinceId
                WHERE CityId=@CityId";
            int registrosAfectados = conn.Execute(updateQuery, city, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("City could not be edited");
            }
        }

        public bool Exist(City city, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Cities ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = city.CityId == 0 ?
                " WHERE CityName=@CityName AND CountryId=@CountryId " :
                " WHERE CityName=@CityName AND CountryId=@CountryId " +
                "AND CityId<>@CityId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, city) > 0;
        }

        public City? GetCityById(int cityId, SqlConnection conn)
        {
            string selectQuery = @"SELECT CityId, CityName, 
                CountryId, StateProvinceId FROM Cities 
                WHERE CityId=@CityId";
            return conn.QuerySingleOrDefault<City>(
                selectQuery, new { @CityId = cityId });
        }

        public int GetCount(SqlConnection conn, Country? selectedCountry, StateProvince? selectedStateProvince, SqlTransaction? tran = null)
        {
            var selectQuery = "SELECT COUNT(*) FROM Cities";
            List<string> conditions = new List<string>();

            if (selectedCountry != null)
            {
                conditions.Add(" WHERE CountryId = @CountryId");

            }
            if (selectedStateProvince != null)
            {
                conditions.Add("StateProvinceId= @StateProvinceId");
            }
            if (conditions.Any())
            {
                selectQuery += string.Join(" AND ", conditions);
                return conn.ExecuteScalar<int>(selectQuery, new
                {
                    @CountryId = selectedCountry?.CountryId,
                    @StateProvinceId = selectedStateProvince?.StateProvinceId
                });

            }
            return conn.ExecuteScalar<int>(selectQuery);
        }

        public List<CityListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT c.CityId, c.CityName, 
                p.CountryName, pe.StateProvinceName FROM Cities c
                INNER JOIN Countries p ON c.CountryId=p.CountryId INNER JOIN 
                StatesProvinces pe ON c.StateProvinceId=pe.StateProvinceId";

            selectQuery += " ORDER BY c.CityName";
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }
            return conn.Query<CityListDto>(selectQuery).ToList();
        }

        public List<City> GetListCombo(SqlConnection conn, Country selectedCountry, StateProvince stateProvince)
        {
            string selectQuery = @"SELECT CityId, CityName, 
                CountryId, StateProvinceId FROM Cities 
                WHERE CountryId=@CountryId AND StateProvinceId=@StateProvinceId";
            return conn.Query<City>(selectQuery, new
            {
                @CountryId = selectedCountry.CountryId,
                @StateProvinceId = stateProvince.StateProvinceId
            }).ToList();
        }

        public int GetPageByRecord(SqlConnection conn, string cityName, int pageSize, SqlTransaction? tran = null)
        {
            var positionQuery = @"
                    WITH OrderedCity AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY CityName) AS RowNum,
                        CityName
                    FROM 
                        Cities
                )
                SELECT 
                    RowNum 
                FROM 
                    OrderedCity 
                WHERE 
                    CityName = @CityName";

            int position = conn.ExecuteScalar<int>(positionQuery, new { CityName = cityName });
            return (int)Math.Ceiling((decimal)position / pageSize);
        }

        public bool IsRelated(int cityId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Addresses 
                WHERE CityId=@CityId";
            return conn.QuerySingle<int>
                (selectQuery, new { cityId }) > 0;
        }
    }
}
