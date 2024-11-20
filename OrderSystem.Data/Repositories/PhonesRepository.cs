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
            var query = "SELECT * FROM Phones WHERE PhoneId = @PhoneId";
            return conn.QuerySingleOrDefault<Phone>(query,
                new { PhoneId = phoneId }, tran);
        }

        public int GetPhoneIdIfExist(Phone phone, SqlConnection conn, SqlTransaction tran)
        {
            var selectQuery = @"SELECT PhoneId FROM Phones 
                WHERE PhoneNumber = @PhoneNumber";
            return conn.ExecuteScalar<int>(selectQuery, phone, tran);
        }

        public List<Phone> GetPhonesByCustomerId(int customerId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"SELECT t.* 
                    FROM Phones t
                    JOIN CustomerPhones ct ON t.PhoneId = ct.PhoneId
                    WHERE ct.CustomerId = @CustomerId ";
            return conn.Query<Phone>(query, new { CustomerId = customerId }, tran).ToList();
        }
    }
}
