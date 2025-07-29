using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class SaleDetailsRepository : ISaleDetailsRepository
    {
        public void Add(SaleDetail details, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO SaleDetails 
                (SaleId, ProductId, ComboId, Quantity, Price) 
                VALUES (@SaleId, @ProductId, @ComboId, @Quantity, @Price); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, details, tran);
            if (primaryKey > 0)
            {
                details.SaleDetailId = primaryKey;
                return;
            }
            throw new Exception("Failed to add sale details.");
        }
    }
}
