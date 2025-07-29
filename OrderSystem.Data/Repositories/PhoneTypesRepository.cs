using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class PhoneTypesRepository : IPhoneTypesRepository
    {
        public List<PhoneType> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT PhoneTypeId, Description FROM PhoneTypes ORDER BY Description";


            return conn.Query<PhoneType>(selectQuery).ToList();

        }
    }
}
