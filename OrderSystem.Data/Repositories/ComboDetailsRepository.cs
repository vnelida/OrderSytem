using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class ComboDetailsRepository : IComboDetailsRepository
    {
        public void Add(ComboDetail detail, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO ComboDetails
                (ComboId, ProductId, Quantity) 
                VALUES (@ComboId, @ProductId, @Quantity); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, detail, tran);
            if (primaryKey > 0)
            {
                detail.ComboDetailId = primaryKey;
                return;
            }
            throw new Exception("The detail could not be added.");
        }

        public void Delete(int itemId, SqlConnection conn, SqlTransaction tran)
        {
            var deleteQuery = @"DELETE FROM ComboDetails 
                WHERE ComboId=@ComboId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { @ComboId = itemId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The detail could not be deleted.");
            }
        }
    }
}
