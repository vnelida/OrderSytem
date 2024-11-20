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
    public class CustomerPhonesRepository : ICustomerPhonesRepository
    {
        public void Add(CustomerPhone customerPhone, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            INSERT INTO CustomerPhones (CustomerId, PhoneId, PhoneTypeId)
            VALUES (@CustomerId, @PhoneId, @PhoneTypeId); ";
            conn.Execute(query, customerPhone, tran);
        }

        public void DeleteCustomerById(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM CustomerPhone WHERE CustomerId = @CustomerId";
            conn.Execute(query, new { CustomerId = customerId }, tran);
        }

        public List<CustomerPhone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM CustomerPhones WHERE CustomerId = @CustomerId";
            return conn.Query<CustomerPhone>(query, new { CustomerId = customerId }, tran).ToList();
        }
    }
}
