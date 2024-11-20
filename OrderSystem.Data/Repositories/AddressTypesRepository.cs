using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class AddressTypesRepository : IAddressTypesRepository
    {
        public List<AddressType> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT AddressTypeId, Description FROM AddressTypes
                    ORDER BY Description";


            return conn.Query<AddressType>(selectQuery).ToList();
        }
    }
}
