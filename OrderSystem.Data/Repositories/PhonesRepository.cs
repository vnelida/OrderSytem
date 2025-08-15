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

        public void Edit(Phone phone, SqlConnection conn, SqlTransaction tran)
        {
            var sql = @"UPDATE Phones
                        SET PhoneNumber = @PhoneNumber
                        WHERE PhoneId = @PhoneId;";

            conn.Execute(sql, phone, transaction: tran);
        }

        public bool Exist(string phoneNumber, SqlConnection conn, SqlTransaction? tran = null)
        {
            var sql = "SELECT COUNT(1) FROM Phones WHERE PhoneNumber = @PhoneNumber";
            var count = conn.ExecuteScalar<int>(sql, new { PhoneNumber = phoneNumber }, transaction: tran);
            return count > 0;
        }

        public Phone? GetPhoneById(int phoneId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var sql = @"SELECT
                        PhoneId,
                        PhoneNumber
                    FROM Phones
                    WHERE PhoneId = @PhoneId;";
            return conn.Query<Phone>(sql, new { PhoneId = phoneId }).SingleOrDefault();
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
