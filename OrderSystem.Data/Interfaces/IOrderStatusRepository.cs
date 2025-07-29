using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IOrderStatusRepository
    {
        OrderStatus? GetOrderStatusByName(string statusName, SqlConnection conn);
        List<OrderStatus> GetListOrderStatus(SqlConnection conn, SqlTransaction? tran = null);
    }
}
