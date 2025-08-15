using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class CustomerPhonesRepository : ICustomerPhonesRepository
    {
        public List<CustomerPhone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var sql = @"
        SELECT
            cp.CustomerId, cp.PhoneId, cp.PhoneTypeId, 
            p.PhoneId, p.PhoneNumber,                  
            pt.PhoneTypeId, pt.Description             
        FROM CustomerPhones cp
        INNER JOIN Phones p ON cp.PhoneId = p.PhoneId
        LEFT JOIN PhoneTypes pt ON cp.PhoneTypeId = pt.PhoneTypeId
        WHERE cp.CustomerId = @CustomerId;
    ";

            var customerPhones = conn.Query<CustomerPhone, Phone, PhoneType, CustomerPhone>(
                sql,
                (cp, p, pt) =>
                {
                    if (cp != null)
                    {
                        cp.Phone = p;       
                        cp.PhoneType = pt;  
                    }
                    return cp; 
                },
                param: new { CustomerId = customerId },
                splitOn: "PhoneId, PhoneTypeId"
            ).ToList();
            return customerPhones;
        }
        public void Add(CustomerPhone customerPhone, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            INSERT INTO CustomerPhones (CustomerId, PhoneId, PhoneTypeId)
            VALUES (@CustomerId, @PhoneId, @PhoneTypeId); ";
            conn.Execute(query, customerPhone, tran);
        }

        public void DeleteCustomerById(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM CustomerPhones WHERE CustomerId = @CustomerId";
            conn.Execute(query, new { CustomerId = customerId }, tran);
        }
    }
}
