using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class StatesProvincesRepository : IStatesProvincesRepository
    {

        public void Add(StateProvince sp, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO StateProvince 
                (StateProvinceName, CountryName) 
                VALUES (@StateProvinciaName, @CountryId); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, sp, tran);
            if (primaryKey > 0)
            {
                sp.StateProvinceId = primaryKey;
                return;
            }
            throw new Exception("State/Province could not be added");
        }

        public void Delete(int stateProvinceId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var deleteQuery = @"DELETE FROM StatesProvinces 
                WHERE StateProvinceId=@StateProvinceId";
            //TODO:Modificar este método
            int registrosAfectados = conn
                .Execute(deleteQuery, new { stateProvinceId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("State/Province could not be deleted");
            }
        }

        public void Edit(StateProvince sp, SqlConnection conn, SqlTransaction? tran = null)
        {
            var updateQuery = @"UPDATE StatesProvince 
            SET StateProvinceName=@StateProvinceName,
                CountryId=@CountryId
                WHERE StateProvinceId=@StateProvinceId";
            //TODO:Ver otra forma
            int registrosAfectados = conn.Execute(updateQuery, sp, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("State/Province could not be edited");
            }
        }

        public bool Exist(StateProvince sp, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM StatesProvinces ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = sp.StateProvinceId == 0 ?
                " WHERE StateProvinceName=@StateProvinceName AND CountryId=@CountryId" :
                " WHERE StateProvinceName=@StateProvinceName AND CountryId=@CountryId " +
                "AND StateProvinceId<>@StateProvinceId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, sp) > 0;
        }

        public int GetCount(SqlConnection conn, Country? country = null, SqlTransaction? tran = null)
        {
            var query = "SELECT COUNT(*) FROM StatesProvince";
            if (country != null)
            {
                query += " WHERE CountryId = @CountryId";
                return conn.ExecuteScalar<int>(query, new { CountryId = country.CountryId });
            }
            return conn.ExecuteScalar<int>(query);
        }

        public List<StateProvinceListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, Order? order = Order.None, Country? country = null, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT pe.StateProvinceId, 
                        pe.StateProvinceName,
                        p.CountryName 
                        FROM StatesProvince pe
                        INNER JOIN Countries p ON pe.CountryId = p.CountryId";

            List<string> conditions = new List<string>();

            if (country != null)
            {
                conditions.Add("pe.CountryId=@countryId");
            }

            if (conditions.Any())
            {
                selectQuery += " WHERE " + string.Join(" AND ", conditions);
            }
            string orderBy = string.Empty;

            switch (order)
            {
                case Order.None:
                    orderBy = " ORDER BY pe.StateProvinceName ";
                    break;
                case Order.CountryAZ:
                    orderBy = " ORDER BY p.CountryName ";
                    break;
                case Order.CountryZA:
                    orderBy = " ORDER BY p.CountryName DESC ";
                    break;
                case Order.StateProvinceAZ:
                    orderBy = " ORDER BY pe.StateProvinceName ";
                    break;
                default:
                    orderBy = " ORDER BY pe.StateProvinceName DESC ";
                    break;

            }
            selectQuery += orderBy;
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return conn.Query<StateProvinceListDto>(selectQuery, new { CountryId = country?.CountryId }).ToList();
        }

        public List<StateProvince> GetListComboStates(Country country, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT StateProvinceId,
                StateProvinceName, CountryId 
                FROM StatesProvinces 
                WHERE CountryId=@CountryId 
                ORDER BY StateProvinceName";
            return conn.Query<StateProvince>(selectQuery,
                new { @CountryId = country.CountryId }).ToList();
        }

        public int GetPageByRecord(SqlConnection conn, string stateProvinceName, int pageSize, SqlTransaction? tran = null)
        {
            var positionQuery = @"
                    WITH StateProvinceOrdered AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY StateProvinceName) AS RowNum,
                        StateProvinceName
                    FROM 
                        StatesProvinces
                )
                SELECT 
                    RowNum 
                FROM 
                    StateProvinceOrdered 
                WHERE 
                    StateProvinceName = @StateProvinceName";

            int position = conn.ExecuteScalar<int>(positionQuery, new { StateProvinceName = stateProvinceName });
            return (int)Math.Ceiling((decimal)position / pageSize);
        }

        public StateProvince? GetStateProvinceById(int stateProvinceId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT StateProvinceId, 
                StateProvinceName, PaisId FROM StatesProvinces 
                WHERE StateProvinceId=@StateProvinceId";

            return conn.QueryFirstOrDefault<StateProvince>(selectQuery,
                new { stateProvinceId });
        }

        public bool IsRelated(int stateProvinceId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Cities 
                WHERE StateProvinceId=@StateProvinceId";
            return conn.QuerySingle<int>
                (selectQuery, new { stateProvinceId }, tran) > 0;
        }
    }
}
