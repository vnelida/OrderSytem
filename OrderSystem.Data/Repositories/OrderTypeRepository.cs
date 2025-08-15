using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class OrderTypeRepository : IOrderTypeRepository
    {
        public List<OrderType> GetListOrderType(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT OrderTypeId, TypeName FROM OrderTypes";
            return conn.Query<OrderType>(selectQuery).ToList();
        }

        public OrderType? GetOrderTypeByName(string typeName, SqlConnection conn)
        {
            var selectQuery = @"SELECT OrderTypeId, TypeName FROM OrderTypes WHERE TypeName = @typeName";
            return conn.QueryFirstOrDefault<OrderType>(selectQuery, new { typeName });
        }
    }
}
