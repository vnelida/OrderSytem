using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        public List<PaymentMethod> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT PaymentMethodId, PaymentMethodName FROM PaymentMethods";
            return conn.Query<PaymentMethod>(selectQuery).ToList();
        }
    }
}
