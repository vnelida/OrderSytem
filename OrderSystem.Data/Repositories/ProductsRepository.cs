using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public void Add(Product product, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"INSERT INTO Products (ProductName, Description, Price, Stock, CategoryId) 
                                VALUES (@ProductName, @Description, @Price, @Stock, @CategoryId); 
                                SELECT CAST(SCOPE_IDENTITY() as int); ";
            product.ItemId = conn.Query<int>(query, product, tran).Single();
        }

        public void Delete(int productId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var deleteQuery = @"DELETE FROM Products 
                               WHERE ProductId=@ProductId";

            int registrosAfectados = conn
                .Execute(deleteQuery, new { productId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The product could not be deleted");
            }
        }

        public void Edit(Product product, SqlConnection conn, SqlTransaction? tran = null)
        {
            var updateQuery = @"UPDATE Products 
                              SET ProductName=@ProductName, Description=@Description, 
                                Price=@Price, Stock=@Stock 
                              WHERE ProductId=@ProductId";
            int registrosAfectados = conn.Execute(updateQuery, product, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The product could not be updated");
            }
        }

        public bool Exist(Product product, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Products ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = product.ItemId == 0 ?
                " WHERE ProductName=@ProductName AND CategoryId=@CategoryId" :
                " WHERE ProductName=@ProductName AND CategoryId=@CategoryId " +
                "AND ProductId<>@ProductId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, product) > 0;
        }

        public int GetCount(SqlConnection conn, Category? category)
        {
            var query = "SELECT COUNT(*) FROM Products";
            if (category != null)
            {
                query += " WHERE CategoryId = @CategoryId";
                return conn.ExecuteScalar<int>(query, new { CategoryId = category.CategoryId });
            }
            return conn.ExecuteScalar<int>(query);            
        }

        public List<ProductListDto> GetList(SqlConnection conn, int currentPage, int pageSize, Order? order = Order.None, Category? category = null, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT p.ProductId, p.ProductName, p.Description, 
                                p.CostPrice, p.Stock, c.CategoryName
                                FROM Products p INNER JOIN Categories c ON 
                                p.CategoryId = c.CategoryId"; 

            List<string> conditions = new List<string>();

            if (category != null)
            {
                conditions.Add("p.CategoryId = @CategoryId");
            }

            if (conditions.Any())
            {
                selectQuery += " WHERE " + string.Join(" AND ", conditions);
            }
            string orderBy = string.Empty;

            switch (order)
            {
                case Order.None:
                    orderBy = " ORDER BY p.ProductId ";
                    break;
                case Order.CategoryAZ:
                    orderBy = " ORDER BY c.CategoryName ";

                    break;
                case Order.CategoryZA:
                    orderBy = " ORDER BY c.CategoryName DESC ";

                    break;
                case Order.ProductAZ:
                    orderBy = " ORDER BY p.ProductName ";

                    break;
                default:
                    orderBy = " ORDER BY p.ProductName DESC ";
                    break;
            }
            selectQuery += orderBy;

            //if (currentPage.HasValue && pageSize.HasValue)
            //{
            //    var offSet = (currentPage.Value - 1) * pageSize;
            //    selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            //}
            //return conn.Query<ProductDto>(selectQuery, new { CategoryId = category?.CategoryId }).ToList();
            var lista = conn.Query<ProductListDto>(selectQuery, new { CategoryId = category?.CategoryId }).ToList();

            return lista.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            //var offset = (currentPage - 1) * pageSize;
            //selectQuery += $" OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            //return conn.Query<ProductDto>(selectQuery, new { CategoryId = category?.CategoryId }, tran).ToList();


        }

        public int GetPageByRecord(SqlConnection conn, string productName, int pageSize)
        {
            var positionQuery = @"
                    WITH ProductOrder AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY ProductName) AS RowNum,
                        ProductName
                    FROM 
                        Products
                )
                SELECT 
                    RowNum 
                FROM 
                    ProductOrder 
                WHERE 
                    ProductName = @ProductName";

            int position = conn.ExecuteScalar<int>(positionQuery, new { ProductName = productName });
            return (int)Math.Ceiling((decimal)position / pageSize);
        }

        public Product? GetProductById(int productId, SqlConnection conn)
        {
            string selectQuery = @"SELECT ProductId, ProductName, Description, Stock, Price, CategoryId 
                FROM Products 
                WHERE ProductId=@ProductId";
            return conn.QuerySingleOrDefault<Product>(selectQuery, new { @ProductId = productId });
        }

        public bool IsRelated(int productId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM XXXX 
                WHERE XXId=@XXId";
            return conn.QuerySingle<int>
                (selectQuery, new { productId }, tran) > 0;
        }
    }
}
