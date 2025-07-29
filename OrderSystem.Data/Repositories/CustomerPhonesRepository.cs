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
                p.PhoneId AS Phone_PhoneId, p.PhoneNumber,
                pt.PhoneTypeId AS PhoneType_PhoneTypeId, pt.Description AS PhoneType_Description
            FROM CustomerPhones cp
            INNER JOIN Phones p ON cp.PhoneId = p.PhoneId
            LEFT JOIN PhoneTypes pt ON cp.PhoneTypeId = pt.PhoneTypeId
            WHERE cp.CustomerId = @CustomerId";

            var customerPhones = conn.Query<
                CustomerPhone, // El objeto principal que Dapper mapea
                Phone,         // El objeto Phone anidado
                PhoneType,     // El objeto PhoneType anidado
                CustomerPhone  // El tipo que se devuelve al final de la lambda
                >(
                sql,
                (cp, p, pt) => // Dapper te da los objetos mapeados
                {
                    if (cp != null) // 'cp' no debería ser null si viene de INNER JOIN
                    {
                        cp.Phone = p; // Asigna el objeto Phone
                        cp.PhoneType = pt; // Asigna el objeto PhoneType
                    }
                    return cp; // Retorna el CustomerPhone completo
                },
                new { @CustomerId = customerId },
                splitOn: "Phone_PhoneId, PhoneType_PhoneTypeId" // Claves para la división
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

        //public List<CustomerPhone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        //{
        //    var query = "SELECT * FROM CustomerPhones WHERE CustomerId = @CustomerId";
        //    return conn.Query<CustomerPhone>(query, new { CustomerId = customerId }, tran).ToList();
        //}
    }
}
