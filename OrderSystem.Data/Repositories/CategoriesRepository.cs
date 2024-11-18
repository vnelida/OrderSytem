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
    public class CategoriesRepository : ICategoriesRepository
    {        
        public CategoriesRepository()
        {
            
        }

        public void Add(Category category, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO Categories (CategoryName) 
                    VALUES(@CategoryName); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, category, tran);
            if (primaryKey > 0)
            {

                category.CategoryId = primaryKey;
                return;
            }

            throw new Exception("The category could not be added");
        }

        public void Delete(int categoryId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM Categories 
                    WHERE CategoryId=@CategoryId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { categoryId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The category could not be deleted");
            }
        }

        public void Edit(Category category, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE Categories 
                    SET CategoryName=@CategoryName 
                    WHERE CategoryId=@CategoryId";

            int registrosAfectados = conn.Execute(updateQuery, category, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("The category could not be updated");
            }
        }

        public bool IsRelated(int categoryId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Products 
                                WHERE CategoryId=@CategoryId";
            return conn.
                QuerySingle<int>(selectQuery, new { categoryId }) > 0;
        }

        public bool Exist(Category category, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Categories ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (category.CategoryId == 0)
                {
                    conditional = "WHERE CategoryName = @CategoryName";
                }
                else
                {
                    conditional = @"WHERE CategoryName = @CategoryName
                            AND CategoryId<>@CategoryId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, category) > 0;

            }
            catch (Exception)
            {

                throw new Exception("The category could not be verified.");
            }
        }

        public List<Category> GetList(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT CategoryId, CategoryName FROM 
                    Categories ORDER BY CategoryName";
            return conn.Query<Category>(selectQuery).ToList();
        }

        public Category? GetCategoryByName(string categoryName, SqlConnection conn)
        {
            var selectQuery = @"SELECT CategoryId, CategoryName FROM Categories WHERE CategoryName = @CategoryName";

            return conn.QueryFirstOrDefault<Category>(selectQuery, new { categoryName });
        }
    }
}
