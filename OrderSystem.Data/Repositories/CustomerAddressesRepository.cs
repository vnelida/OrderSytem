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
    public class CustomerAddressesRepository : ICustomerAddressesRepository
    {
        public void Add(CustomerAddress customerAddress, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @" INSERT INTO CustomerAddresses (CustomerId, AddressId, AddressTypeId)
                VALUES (@CustomerId, @AddressId, @AddressTypeId);";
            conn.Execute(query, customerAddress, tran);
        }

        public void DeleteByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM CustomerAddresses WHERE CustomerId = @CustomerId";
            conn.Execute(query, new { CustomerId = customerId }, tran);
        }

        public List<CustomerAddress> GetAddressByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM CustomerAddresses WHERE CustomerId = @CustomerId";
            return conn.Query<CustomerAddress>(query, new { CustomerId = customerId }, tran).ToList();
        }
    }
}
