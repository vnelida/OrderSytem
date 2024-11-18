using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICategoriesRepository
    {
        void Add(Category category, SqlConnection conn, SqlTransaction? tran = null);
        void Delete(int categoryId, SqlConnection conn, SqlTransaction? tran = null);
        void Edit(Category category, SqlConnection conn, SqlTransaction? tran = null);
        bool IsRelated(int categoryId, SqlConnection conn, SqlTransaction? tran = null);
        bool Exist(Category category, SqlConnection conn, SqlTransaction? tran = null);
        List<Category> GetList(SqlConnection conn, SqlTransaction? tran = null);
        Category? GetCategoryByName(string categoryName, SqlConnection conn);
    }
}
