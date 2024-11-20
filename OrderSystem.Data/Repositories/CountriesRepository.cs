using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        public void Add(Country country, SqlConnection conn, SqlTransaction? tran = null)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO Countries (CountryName) 
                VALUES(@CountryName); SELECT CAST(SCOPE_IDENTITY() as int)";

            primaryKey = conn.QuerySingle<int>(insertQuery, country, tran);
            if (primaryKey > 0)
            {
                country.CountryId = primaryKey;
                return;
            }

            throw new Exception("Country could not be added.");
        }

        public void Delete(int paisId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM Countries 
                WHERE CountryId=@CountryId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { paisId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("Country could not be deleted");
            }
        }

        public void Edit(Country country, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE Countries SET CountryName=@CountryName 
                WHERE CountryId=@CountryId";

            int registrosAfectados = conn.Execute(updateQuery, country, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("Country could not be edited");
            }
        }

        public bool Exist(Country country, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Countries ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (country.CountryId == 0)
                {
                    conditional = "WHERE CountryName = @CountryName";
                }
                else
                {
                    conditional = @"WHERE CountryName = @CountryName
                            AND CountryId<>@CountryId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, country) > 0;

            }
            catch (Exception)
            {

                throw new Exception("Failed to check if country exists.");
            }

        }

        public int GetCount(SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Countries";
            return conn.ExecuteScalar<int>(selectQuery);
        }

        public Country? GetCountryById(int countryId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT CountryId, CountryName, 
                 FROM Countries 
                WHERE CountryId=@CountryId";
            return conn.QuerySingleOrDefault<Country>(
                selectQuery, new { CountryId = countryId });
        }

        public List<Country>? GetList(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT CountryId, CountryNamw FROM 
                Countries ORDER BY CountryName";
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }
            return conn.Query<Country>(selectQuery).ToList();

        }

        public int GetPageByRecord(SqlConnection conn, string countryName, int pageSize)
        {
            var positionQuery = @"
                    WITH OrderedCountry AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY CountryName) AS RowNum,
                        CountryName
                    FROM 
                        Countries
                )
                SELECT 
                    RowNum 
                FROM 
                    OrderedCountry 
                WHERE 
                    CountryName = @CountryName";

            int position = conn.ExecuteScalar<int>(positionQuery, new { CountryName = countryName });
            return (int)Math.Ceiling((decimal)position / pageSize);
        }

        public bool IsRelated(int typeId, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) 
                        FROM StatesProvinces 
                            WHERE CountryId=@CountryId";
                return conn.
                    QuerySingle<int>(selectQuery, new { typeId }) > 0;

            }
            catch (Exception)
            {

                throw new Exception("Failed to check if country exists.");
            }
        }
    }
}
