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

        public IEnumerable<ComboDetail> GetComboDetails(int comboId, SqlConnection conn, SqlTransaction tran)
        {
            var sql = @"
        SELECT
            cd.ComboDetailId,
            cd.ComboId,
            cd.ProductId,
            cd.Quantity,
            p.ProductId,
            p.ProductName,
            p.Stock
        FROM ComboDetails cd
        INNER JOIN Products p ON cd.ProductId = p.ProductId
        WHERE cd.ComboId = @ComboId;
    ";

            return conn.Query<ComboDetail, Product, ComboDetail>(
                sql,
                (comboDetail, product) =>
                {
                    // Asigna el objeto Product poblado a la propiedad anidada en ComboDetail.
                    comboDetail.Product = product;
                    return comboDetail;
                },
                param: new { ComboId = comboId },
                transaction: tran,
                splitOn: "ProductId"
            );
        }
    }
}
