using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IOrderTypeRepository
    {
        OrderType? GetOrderTypeByName(string typeName, SqlConnection conn);
        List<OrderType> GetListOrderType(SqlConnection conn, SqlTransaction? tran = null);
    }
}
