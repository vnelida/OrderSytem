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
    public class OrderStatusRepository : IOrderStatusRepository
    {
        public List<OrderStatus> GetListOrderStatus(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT OrderStatusId, StatusName FROM OrderStatuses";
            return conn.Query<OrderStatus>(selectQuery).ToList();
        }

        public OrderStatus? GetOrderStatusByName(string statusName, SqlConnection conn)
        {
            var selectQuery = @"SELECT OrderStatusId, StatusName FROM OrderStatuses WHERE StatusName = @statusName";
            return conn.QueryFirstOrDefault<OrderStatus>(selectQuery, new { statusName });
        }
    }
}
