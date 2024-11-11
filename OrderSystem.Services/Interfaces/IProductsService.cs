using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductsService
    {
        void Delete(int productId);
        bool IsRelated(int productId);
        bool Exist(Product product);
        List<ProductListDto> GetList(int currentPage, int pageSize, Order? order = Order.None, Category? category = null);
        void Save(Product product);
        Product GetProductById(int productId);
        int GetCount(Category? category = null);
        int GetPageByRecord(string productName, int pageSize);
    }
}
