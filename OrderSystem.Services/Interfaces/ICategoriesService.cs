using Entities.Entities;
using Entities.Enums;

namespace Services.Interfaces
{
    public interface ICategoriesService
    {
        void Delete(int categoryId);
        bool IsRelated(int categoryId);
        bool Exist(Category category);
        List<Category> GetList(int? currentPage=0, int? pageSize = 0, Order? order = Order.None);
        void Save(Category category);
        Category? GetCategoryByName(string categoryName);
        int GetCount();
    }
}
