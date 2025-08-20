using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public void Add(Payment payment, SqlConnection conn, SqlTransaction tran)
        {
            var sql = @"
            INSERT INTO Payments (SaleId, PaymentMethodID, Amount, PaymentDate)
            VALUES (@SaleId, @PaymentMethodID, @Amount, @PaymentDate);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            // Ejecuta la consulta y asigna el PaymentID generado al objeto
            payment.PaymentID = conn.QuerySingle<int>(sql, payment, transaction: tran);

        }
    }
}
