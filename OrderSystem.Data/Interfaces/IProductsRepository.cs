using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IProductsRepository
    {
        void Add(Product product, SqlConnection conn, SqlTransaction? tran = null);
        void Delete(int productId, SqlConnection conn, SqlTransaction? tran = null);
        void Edit(Product product, SqlConnection conn, SqlTransaction? tran = null);
        bool IsRelated(int productId, SqlConnection conn, SqlTransaction? tran = null);
        bool Exist(Product product, SqlConnection conn, SqlTransaction? tran = null);
        List<ProductListDto> GetList(SqlConnection conn, int currentPage, int pageSize, Order? order = Order.None, Category? category = null, SqlTransaction? tran = null);
        Product? GetProductById(int productId, SqlConnection conn);
        int GetCount(SqlConnection conn, Category? category);
        int GetPageByRecord(SqlConnection conn, string productName, int pageSize);
    }
}
