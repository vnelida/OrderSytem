using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoriesService
    {
        void Delete(int categoryId);
        bool IsRelated(int categoryId);
        bool Exist(Category category);
        List<Category> GetList();
        void Save(Category category);
    }
}
