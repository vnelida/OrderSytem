using Dapper;
using Data.Interfaces;
using Entities.Entities;
using Entities.Enums;
using System.Data.SqlClient;

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

        public List<Category> GetList(SqlConnection conn, int? currentPage = 0, int? pageSize = 0, Order? order = Order.None, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT CategoryId, CategoryName FROM 
                    Categories";

            string orderBy = string.Empty;

            switch (order)
            {
                case Order.None:
                    orderBy = " ORDER BY CategoryId DESC ";
                    break;
                case Order.CategoryAZ:
                    orderBy = " ORDER BY CategoryName ";
                    break;
                default:
                    orderBy = " ORDER BY CategoryName DESC ";
                    break;
            }
            selectQuery += orderBy;
            if (currentPage != 0)
            {
                if (currentPage.HasValue && pageSize.HasValue)
                {
                    var offSet = (currentPage.Value - 1) * pageSize;
                    selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
                }
            }

            return conn.Query<Category>(selectQuery).ToList();
        }

        public Category? GetCategoryByName(string categoryName, SqlConnection conn)
        {
            var selectQuery = @"SELECT CategoryId, CategoryName FROM Categories WHERE CategoryName = @CategoryName";

            return conn.QueryFirstOrDefault<Category>(selectQuery, new { categoryName });
        }

        public int GetCount(SqlConnection conn)
        {
            var query = "SELECT COUNT(*) FROM Categories";

            return conn.ExecuteScalar<int>(query);

        }
    }
}
