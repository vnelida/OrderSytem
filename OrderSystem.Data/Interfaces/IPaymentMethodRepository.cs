using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetList(SqlConnection conn, SqlTransaction? tran = null);

    }
}
