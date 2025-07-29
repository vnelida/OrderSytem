using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class PhonesRepository : IPhonesRepository
    {
        public void Add(Phone phone, SqlConnection conn, SqlTransaction? tran = null)
        {
            var insertQuery = @" INSERT INTO Phones (PhoneNumber)
                    VALUES (@PhoneNumber);
                SELECT CAST(SCOPE_IDENTITY() as int); ";
            phone.PhoneId = conn.Query<int>(insertQuery, phone, tran).Single();
        }

        public Phone? GetPhoneById(int phoneId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var sql = @"
                SELECT
                    p.PhoneId, p.PhoneNumber, -- Columnas de Phone
                    pt.PhoneTypeId AS PhoneType_PhoneTypeId, pt.Description AS PhoneType_Description -- Columnas de PhoneType (con alias)
                FROM Phones p
                LEFT JOIN PhoneTypes pt ON p.PhoneTypeId = pt.PhoneTypeId -- LEFT JOIN para el tipo de teléfono
                WHERE p.PhoneId = @PhoneId";

            // Dapper mapeará a Phone y PhoneType, y luego a Phone (el tipo final)
            var result = conn.Query<Phone, PhoneType, Phone>(
                sql,
                (p, pt) => // p: Phone, pt: PhoneType
                {
                    if (p != null) // Si el objeto Phone principal se mapeó
                    {
                        p.PhoneType = pt; // Asigna el PhoneType al objeto Phone
                    }
                    return p; // Devuelve el Phone (con PhoneType asignado)
                },
                new { @PhoneId = phoneId },
                splitOn: "PhoneType_PhoneTypeId", // La división para el objeto PhoneType
                transaction: tran // Pasa la transacción si existe
            ).SingleOrDefault(); // SingleOrDefault porque esperamos un solo teléfono

            return result;
            //var query = "SELECT * FROM Phones WHERE PhoneId = @PhoneId";
            //return conn.QuerySingleOrDefault<Phone>(query,
            //    new { PhoneId = phoneId }, tran);
        }

        public int GetPhoneIdIfExist(Phone phone, SqlConnection conn, SqlTransaction tran)
        {
            var selectQuery = @"SELECT PhoneId FROM Phones 
                WHERE PhoneNumber = @PhoneNumber";
            return conn.ExecuteScalar<int>(selectQuery, phone, tran);
        }

        public List<Phone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var sql = @"
        SELECT
            p.PhoneId, p.PhoneNumber, -- Columnas de Phone
            pt.PhoneTypeId AS PhoneType_PhoneTypeId, pt.Description AS PhoneType_Description -- Datos de PhoneType
        FROM Phones p
        INNER JOIN CustomerPhones cp ON p.PhoneId = cp.PhoneId -- Unir a CustomerPhones para filtrar por CustomerId
        LEFT JOIN PhoneTypes pt ON cp.PhoneTypeId = pt.PhoneTypeId -- Unir a PhoneTypes
        WHERE cp.CustomerId = @CustomerId"; // Filtrar por CustomerId

            var phones = conn.Query<
                Phone,         // Objeto principal: Phone
                PhoneType,     // Objeto anidado en Phone
                Phone          // El tipo que se devuelve de la lambda (el Phone con su anidado)
                >(
                sql,
                (p, pt) => // Dapper te da los objetos mapeados
                {
                    if (p != null) // 'p' es el objeto Phone
                    {
                        p.PhoneType = pt; // Asignar el objeto PhoneType a Phone.PhoneType
                    }
                    return p; // Devolver el objeto Phone completo
                },
                new { @CustomerId = customerId },
                splitOn: "PhoneType_PhoneTypeId", // La clave para dividir
                transaction: tran // Pasa la transacción
            ).ToList();

            return phones;
        }

        //public List<Phone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        //{
        //    var query = @"SELECT t.* 
        //            FROM Phones t
        //            JOIN CustomerPhones ct ON t.PhoneId = ct.PhoneId
        //            WHERE ct.CustomerId = @CustomerId ";
        //    return conn.Query<Phone>(query, new { CustomerId = customerId }, tran).ToList();
        //}
    }
}
