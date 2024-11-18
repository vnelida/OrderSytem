using Entities.Entities;

namespace Services.Interfaces
{
    public interface ICategoriesService
    {
        void Delete(int categoryId);
        bool IsRelated(int categoryId);
        bool Exist(Category category);
        List<Category> GetList();
        void Save(Category category);
        Category? GetCategoryByName(string categoryName);
    }
}
