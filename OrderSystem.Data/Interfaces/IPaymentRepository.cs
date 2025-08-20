using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IPaymentRepository
    {
        void Add(Payment payment, SqlConnection conn, SqlTransaction tran);
    }
}
